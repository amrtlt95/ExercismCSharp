using System;

class RemoteControlCar
{
    private readonly int _speed;
    private int _batteryDrain, _distanceDriven;
    private int _battery = 100;

    public RemoteControlCar(int Speed , int BatteryDrain)
    {
        _batteryDrain = BatteryDrain;
        _speed = Speed;
    }
    public int TotalDistance() => _battery / _batteryDrain * _speed;
    public bool BatteryDrained() => _battery < _batteryDrain;

    public int DistanceDriven()
    {
        return _distanceDriven;
    }

    public void Drive()
    {
        if(_battery >= _batteryDrain)
        {
            _battery -= _batteryDrain;
            _distanceDriven += _speed;
        }
    }

    public static RemoteControlCar Nitro() => new RemoteControlCar(50, 4);


}

class RaceTrack
{
    // TODO: define the constructor for the 'RaceTrack' class
    private int _distance;
    public RaceTrack(int Distance)
    {
        _distance = Distance;
    }

    public bool TryFinishTrack(RemoteControlCar car) => car.TotalDistance() >= _distance;
}
