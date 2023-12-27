namespace AutoMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var user = new User();
            user.Id = 1;
            user.Age = 30;
            user.Name = "Test";
            var userDto = new UserDTO();
            Mapper<User, UserDTO> mapper = new Mapper<User, UserDTO>();
            var dto = mapper.Map(user);
            foreach (var item in dto.GetType().GetProperties())
            {
                Console.WriteLine(item.Name + "  " + item.GetValue(dto));
            }
        }
        public class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int Id { get; set; }
        }
        public class UserDTO
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        public interface IMapper<Tsource, TDestination>
        {
            TDestination Map(Tsource source);
        }
        public class Mapper<TSource, TDestination> : IMapper<TSource, TDestination>
        {
            TDestination destination =Activator.CreateInstance<TDestination>();
            public TDestination Map(TSource source)
            {
                foreach (var prop in source.GetType().GetProperties())
                {
                    foreach (var item in destination.GetType().GetProperties())
                    {
                        if (prop.Name.ToLower() == item.Name.ToLower())
                        {
                            item.SetValue(destination,prop.GetValue(source));
                        }
                    }
                }
                return destination;
            }
        }
    }
}