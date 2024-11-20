namespace BlazorTestingExample.Core.Common;

public interface IMapper<T1, T2>
{
    T1? Map(T2? input);
    T2? Map(T1? input);
    IEnumerable<T1> Map(IEnumerable<T2> input);
    IEnumerable<T2> Map(IEnumerable<T1> input);
}

public class Mapper<T1, T2> : IMapper<T1, T2>
{
    public virtual IEnumerable<T1> Map(IEnumerable<T2> input)
    {
        return input.Select(Map).Where(i => i != null)!;
    }

    public virtual IEnumerable<T2> Map(IEnumerable<T1> input)
    {
        return input.Select(Map).Where(i => i != null)!;
    }

    public virtual T1? Map(T2? input)
    {
        return MapFromTypeToAnother<T1, T2>(input);
    }

    public virtual T2? Map(T1? input)
    {
        return MapFromTypeToAnother<T2, T1>(input);
    }

    private T3? MapFromTypeToAnother<T3, T4>(T4? input)
    {
        if (input == null) return default(T3);
        var objType = input.GetType();
        var targetType = typeof(T3);
        var targetObject = Activator.CreateInstance(targetType);


        var properties = objType.GetProperties();
        var targetProps = targetType.GetProperties();
        foreach (var property in targetProps)
        {
            var sourceProp = properties.FirstOrDefault(p => p.Name == property.Name
                                                            && p.PropertyType == property.PropertyType);

            if (sourceProp != null)
            {
                var sourceValue = sourceProp.GetValue(input);
                property.SetValue(targetObject, sourceValue);
            }
        }

        return (T3)targetObject!;
    }
}
