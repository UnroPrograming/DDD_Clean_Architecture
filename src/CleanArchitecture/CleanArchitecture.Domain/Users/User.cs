using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Users.Events;

namespace CleanArchitecture.Domain.Users
{
    public class User : Entity
    {
        private User(Guid id, Nombre? nombre, Apellido? apellido, Email? email) : base(id)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
        }

        public Nombre? Nombre { get; private set; }
        public Apellido? Apellido { get; private set; }
        public Email? Email { get; private set; }

        public static User Create(Nombre nombre, Apellido apellido, Email email)
        {
            var user = new User(Guid.NewGuid(), nombre, apellido, email);
            user.AddDomainEvent(new UserCreatedDomainEvent(user.Id));

            return user;
        }
    }


    //Si nos fijamos no se puede usar un constructor público porque Entity necesita recibir el Id por el constructor
    public class User2 : Entity
    {
        public User2(Guid id, Nombre? nombre, Apellido? apellido, Email? email) : base(id)
        {
            //Id = Guid.NewGuid(); //No se le puede asigna directamente el valor porque tiene private set
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
        }

        public Nombre? Nombre { get; private set; }
        public Apellido? Apellido { get; private set; }
        public Email? Email { get; private set; }
    }
}
