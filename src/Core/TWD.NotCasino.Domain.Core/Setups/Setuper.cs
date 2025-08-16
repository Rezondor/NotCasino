using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace TWD.NotCasino.Domain.Core.Setups;

public class Setuper
{
    public static void SetupModels(ModelBuilder modelBuilder)
    {
        // Задаем интерфейс, от которого хотим найти все реализации
        var interfaceType = typeof(ISetup);

        // Получаем все типы из текущего домена приложения
        var types = Assembly.GetExecutingAssembly().GetTypes();

        // Фильтруем типы, которые реализуют заданный интерфейс
        var implementingTypes = types.Where(t => interfaceType.IsAssignableFrom(t) && t.IsClass).ToList();

        var setupers = implementingTypes.Select(x => x.GetConstructors().First().Invoke([]) as ISetup).OrderBy(x => x!.OrderNumber);

        foreach (var setuper in setupers)
        {
            setuper?.Setup(modelBuilder);
        }
    }
}
