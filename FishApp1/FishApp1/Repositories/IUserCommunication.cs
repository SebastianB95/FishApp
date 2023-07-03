namespace FishApp1.Repositories;

public interface IUserCommunication
{
    string  Menu();

    void AddFishs();

    void RemoveFish();

    void WriteAllToConsole();

    void Saveinfo();

}
