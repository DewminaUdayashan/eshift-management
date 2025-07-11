using Dapper;
using System.Data;

public class UserTypeHandler : SqlMapper.TypeHandler<UserType>
{
    public override void SetValue(IDbDataParameter parameter, UserType value)
    {
        parameter.Value = value.ToString();
    }

    public override UserType Parse(object value)
    {
        if (value is string str && Enum.TryParse<UserType>(str, out var result))
            return result;

        throw new ArgumentException($"Cannot convert '{value}' to UserType enum.");
    }
}
