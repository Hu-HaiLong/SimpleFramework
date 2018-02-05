
public class PlayerData  {

    int id;
    string name;
    int power;
    int energy;
    int healthy;

    int actionValue; //行动值

    int strength;
    int intelligence;

    public PlayerData(int id, string name, int power, int energy, int healthy, int strength, int intelligence, int actionValue)
    {
        this.id = id;
        this.name = name;
        this.power = power;
        this.energy = energy;
        this.healthy = healthy;
        this.strength = strength;
        this.actionValue = actionValue;
        this.intelligence = intelligence;
    }

    public int Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public int Power
    {
        get
        {
            return power;
        }

        set
        {
            power = value;
        }
    }

    public int Energy
    {
        get
        {
            return energy;
        }

        set
        {
            energy = value;
        }
    }

    public int Healthy
    {
        get
        {
            return healthy;
        }

        set
        {
            healthy = value;
        }
    }

    public int Strength
    {
        get
        {
            return strength;
        }

        set
        {
            strength = value;
        }
    }

    public int Intelligence
    {
        get
        {
            return intelligence;
        }

        set
        {
            intelligence = value;
        }
    }

    public int ActionValue
    {
        get
        {
            return actionValue;
        }

        set
        {
            actionValue = value;
        }
    }
}
