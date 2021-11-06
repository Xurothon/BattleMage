using UnityEngine;

public class Helpers : MonoBehaviour
{
    public static Helpers Instance { get; private set; }
    public UIHelper UIHelper { get { return _uiHelper; } }
    public PositionChanger PositionChanger { get { return _positionChanger; } }
    public ManaTracker ManaTracker { get { return _manaTracker; } }
    public CoinsCounter CoinsCounter { get { return _coinsCounter; } }
    public PowerShop PowerShop { get { return _powerShop; } }
    public SphereCreater SphereCreater { get { return _sphereCreater; } }
    public LevelLoader LevelLoader { get { return _levelLoader; } }
    public Player Player => _player;
    [SerializeField] private UIHelper _uiHelper;
    [SerializeField] private PositionChanger _positionChanger;
    [SerializeField] private ManaTracker _manaTracker;
    [SerializeField] private CoinsCounter _coinsCounter;
    [SerializeField] private PowerShop _powerShop;
    [SerializeField] private SphereCreater _sphereCreater;
    [SerializeField] private LevelLoader _levelLoader;
    [SerializeField] private Player _player;

    private void Awake()
    {
        Instance = this;
    }
}
