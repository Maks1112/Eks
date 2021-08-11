namespace Server.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Models.Entities;
    public class DataManagerMCC : DbContext
    {
        // Контекст настроен для использования строки подключения "DataManagerMCC" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "Server.Data.DataManagerMCC" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "DataManagerMCC" 
        // в файле конфигурации приложения.
        public DataManagerMCC()
            : base("name=DataManagerMCC")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Chat> Chats{ get; set; }
        public virtual DbSet<Group> Groups{ get; set; }
        public virtual DbSet<Server> Servers{ get; set; }
        public virtual DbSet<User> Users{ get; set; }
  

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}