using UnityEngine;
using Zenject;

namespace LeelGenerator
{
    public class LevelGeneratorManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] _prefabChankArray;
        [SerializeField] private int _countPlatform;
        [SerializeField] private Transform _topLimit;
        [SerializeField] private Transform _downLimit;
        [SerializeField] private Transform _startLeftPosition;

        private float _startXPosition;
        private float _topYLimit;
        private float _downYLimit;
        private float _xShift = 13f;
        private float _verticalShift = 2f;

        private ChanksOwner _chanksOwner;
        private GameObject _pastChank;
        private float _pastChankYPosition;
        private FinishChankOwner _finishChankOwner;

        [Inject]
        private void Construct(ChanksOwner chanksOwnerArg, FinishChankOwner finishChankOwnerArg)
        {
            _chanksOwner = chanksOwnerArg;
            _finishChankOwner = finishChankOwnerArg;
        }

        void Start()
        {
            PrepareDataForChankPositionLikeCurveGenerator();
            PrepareChanksArray();
            GenerateLevel();
        }

        private void PrepareChanksArray()
        {
            _prefabChankArray = _chanksOwner.GetChanksArray();
        }

        private void PrepareDataForChankPositionLikeCurveGenerator()
        {
            _startXPosition = _startLeftPosition.position.x;
            _topYLimit = _topLimit.position.y;
            _downYLimit = _downLimit.position.y;
            _pastChankYPosition = _startLeftPosition.position.y; // чтобы пещера начинала с нужной нам высоты
            _targetForChankSectionEndYPosition = _startLeftPosition.position.y;
        }

        private void GenerateLevel()
        {
            for (int i = 0; i < _countPlatform; i++)
            {
                GameObject randomPrefab = GetRandomChank();
                SpawnRegularChank(i, randomPrefab);
            }

            SpawnFinishChank();
        }

        private void SpawnFinishChank()
        {
            GameObject finishChank = _finishChankOwner.GetFinishChank();
            MoveFinishChankToEndTheLevel(finishChank);
        }

        private void MoveFinishChankToEndTheLevel(GameObject finishChankArg)
        {
            Vector3 newPosition = CreatePositionForChank(_countPlatform);
            finishChankArg.transform.position = newPosition;
        }

        private void SpawnRegularChank(int step, GameObject chank)
        {
            Vector3 newPosition = CreatePositionForChank(step);
            SpawnAsNewChankInScene(chank, newPosition);
        }

        private Vector3 CreatePositionForChank(int step)
        {
            Vector3 newPosition = Vector3.zero;
            newPosition.x = (step * _xShift) + _startXPosition;
            newPosition.y = GetYPostionForChank();
            newPosition.z =  Random.Range(-0.02f, -0.01f); // fix z - flickering 
            return newPosition;
        }

        private float _targetForChankSectionEndYPosition;

        private float GetYPostionForChank()
        {
            float randomYPosition = 0f;

            if (_targetForChankSectionEndYPosition > _pastChankYPosition)
            {
                randomYPosition = _pastChankYPosition + _verticalShift;
            }
            else
            {
                randomYPosition = _pastChankYPosition - _verticalShift;
            }
        
            CheckTargerYPositionRelise( randomYPosition , _targetForChankSectionEndYPosition);

            _pastChankYPosition = randomYPosition;
            return randomYPosition;
        }

        private void CheckTargerYPositionRelise(float yNow, float yTarget)
        {
            float dif = Mathf.Abs( yNow - yTarget );

            if (dif < 2.5f)
            {
                _targetForChankSectionEndYPosition = MakeRandomY();
            }
        }


        private float MakeRandomY()
        {
            return  Random.Range(_downYLimit, _topYLimit);
        }
    
        private GameObject GetRandomChank()
        {
            GameObject randomChank = null;

            for (int i = 0; i < 100; i++)
            {
                int randomIndexPrefab = Random.Range(0, _prefabChankArray.Length);
                randomChank = _prefabChankArray[randomIndexPrefab];
                if (randomChank != _pastChank)
                    break;
            }
        
            _pastChank = randomChank;
            return randomChank;
        }

        private void SpawnAsNewChankInScene(GameObject prefabArg, Vector3 positionArg)
        {
            GameObject newChank = Instantiate(prefabArg, positionArg, Quaternion.identity);
            newChank.SetActive(true);
        }

   
    }
}