using System.Security.AccessControl;

namespace solid_principles;

public class LiskovsSubstitution
{
    //Yalnızca birbirine benzediği için birbirinin yerine kullanmamak.
    //ÖRN:
    // class User
    // {
    //     public int Id { get; set; }
    //     public string FirstName { get; set; }
    //     public string Lastname { get; set; }
    //     public string TcNo { get; set; }
    // }

    //Bir gerçek kullanıcımız olsun. Bir de şirket olarak kaydolacak bir kullanıcımız olsun.
    //Gerçek kullanıcının TC numarası olabilir.Fakat şirketin olamaz.İki tip kullanıcı için de Tc numarası kullanıp,
    //tipi şirket olan kullanıcılar için TC kısmına vergi numarası girmek işimizi çözüyor gibi görünebilir fakat SOLID'e aykırıdır. 
    //Bunun yerine aşapıdaki kullanımları yapmalıyız.
    
    class User
    {
        public int Id { get; set; }
        
    }
    class GercekMusteri:User
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string TcNo { get; set; }
    }

    class SirketMusteri:User
    {
        public string Name { get; set; }
        public string VergiNo { get; set; }
    }

}