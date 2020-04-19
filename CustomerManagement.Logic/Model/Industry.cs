using CSharpFunctionalExtensions;
using CustomerManagement.Logic.Common;

namespace CustomerManagement.Logic.Model
{
    public class Industry : Entity
    {
        public static readonly Industry Cars = new Industry(1, "Cars");
        public static readonly Industry Pharmacy = new Industry(2, "Pharmacy");
        public static readonly Industry Other = new Industry(3, "Other");

        public Industry(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public virtual string Name { get; protected set; }

        public static Result<Industry> Get(Maybe<string> industry)
        {
            if (industry.HasNoValue)
                return Result.Fail<Industry>("Industry name is nor especified");

            if (industry.Value == Cars.Name)
                return Result.Ok(Cars);
            if (industry.Value == Pharmacy.Name)
                return Result.Ok(Pharmacy);
            if (industry.Value == Other.Name)
                return Result.Ok(Other);

            return Result.Fail<Industry>("Industry name is invalid");
        }


    }
}
