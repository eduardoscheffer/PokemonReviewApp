using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Data
{
    public class DataContext : DbContext
    {
        // Cada DbSet representa uma coleção de entidades do mesmo tipo, que corresponde a uma tabela no banco de dados.
        // Os DbSet simplificam muito a interação com o banco de dados ao abstrair as operações SQL em operações orientadas a objetos. Isso torna mais fácil e eficiente o gerenciamento de dados no Entity Framework.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }
        public DbSet<PokemonOwner> PokemonOwners { get; set; }
        public DbSet<PokemonCategory> PokemonCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        /*
         Ao passar o DbContextOptions no construtor, você permite que as opções de configuração sejam definidas fora da classe MeuDbContext. Isso é útil porque, dependendo do ambiente (por exemplo, desenvolvimento, teste ou produção), você pode querer configurar o banco de dados de maneiras diferentes.
         */
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        /*
        O método OnModelCreating é um método que faz parte do DbContext no Entity Framework Core. Ele é responsável por configurar o modelo de dados (entidades) que será utilizado pelo Entity Framework durante a criação do banco de dados e as operações de consulta, inserção, atualização e exclusão de registros.
        É uma parte importante do DbContext que permite que você defina várias configurações personalizadas para o modelo de dados, garantindo que o Entity Framework se comporte de acordo com as suas necessidades específicas.
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar a tabela de junção (PokemonCategory) usando o metodo HasKey para definir a chave primária composta das duas chaves estrangeiras (PokemonId e CategoryId).
            modelBuilder.Entity<PokemonCategory>()
                    .HasKey(pc => new { pc.PokemonId, pc.CategoryId });

            // Configurar o relacionamento many-to-many entre Pokemon e Category
            modelBuilder.Entity<PokemonCategory>()
                    .HasOne(p => p.Pokemon)
                    .WithMany(pc => pc.PokemonCategories)
                    .HasForeignKey(pc => pc.PokemonId);
            modelBuilder.Entity<PokemonCategory>()
                    .HasOne(p => p.Category)
                    .WithMany(pc => pc.PokemonCategories)
                    .HasForeignKey(p => p.CategoryId);

            // Configurar a tabela de junção (PokemonOwner) usando o metodo HasKey para definir a chave primária composta das duas chaves estrangeiras (PokemonId e OwnerId).
            modelBuilder.Entity<PokemonOwner>()
                    .HasKey(pc => new {pc.PokemonId, pc.OwnerId});

            // Configurar o relacionamento many-to-many entre Pokemon e Owner
            modelBuilder.Entity<PokemonOwner>()
                    .HasOne(p => p.Pokemon)
                    .WithMany(pc => pc.PokemonOwners)
                    .HasForeignKey(pc => pc.PokemonId);
            modelBuilder.Entity<PokemonOwner>()
                    .HasOne(p => p.Owner)
                    .WithMany(pc => pc.PokemonOwners)
                    .HasForeignKey(p => p.OwnerId);

            // seeding Category:
            modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "Grass" },
                    new Category { Id = 2, Name = "Fire" },
                    new Category { Id = 3, Name = "Water" }
                );
            // Seeding para a entidade Country
            modelBuilder.Entity<Country>().HasData(
                    new Country { Id = 1, Name = "Kanto" },
                    new Country { Id = 2, Name = "Johto" },
                    new Country { Id = 3, Name = "Hoenn" }
                
            );

            // Seeding para a entidade Reviewer
            modelBuilder.Entity<Reviewer>().HasData(
                    new Reviewer { Id = 1, FirstName = "Ash", LastName = "Ketchum" },
                    new Reviewer { Id = 2, FirstName = "Misty", LastName = "Ketshup" },
                    new Reviewer { Id = 3, FirstName = "Brock", LastName = "Mustard" }
            );
            // Seeding para a entidade Owner
            modelBuilder.Entity<Owner>().HasData(
                    new Owner { Id = 1, FirstName = "Ragnar", LastName = "Lothbrock", Gym = "Gym1" , CountryId = 1},
                    new Owner { Id = 2, FirstName = "Lagertha", LastName = "Lothbrock", Gym = "Gym2", CountryId = 2 },
                    new Owner { Id = 3, FirstName = "Ivar", LastName = "Boneless", Gym = "Gym3", CountryId = 3 }
            );

            // Seeding para a entidade Pokemon
            modelBuilder.Entity<Pokemon>().HasData(
                    new Pokemon { Id = 1, Name = "Pikachu", BirthDate = DateTime.Now },
                    new Pokemon { Id = 2, Name = "Bulbasaur", BirthDate = DateTime.Now },
                    new Pokemon { Id = 3, Name = "Squirtle", BirthDate = DateTime.Now }
            );
            // Seeding para a entidade Review
            modelBuilder.Entity<Review>().HasData(
                    new Review { Id = 1, Title = "Title1", Text = "Text 1", Rating = 9, ReviewerId = 1, PokemonId = 1 },
                    new Review { Id = 2, Title = "Title2", Text = "Text 2", Rating = 10, ReviewerId = 2, PokemonId = 2 },
                    new Review { Id = 3, Title = "Title3", Text = "Text 3", Rating = 7, ReviewerId = 3, PokemonId = 3 }
            );

            // Seeding para a entidade PokemonCategory
            modelBuilder.Entity<PokemonCategory>().HasData(
                    new PokemonCategory { PokemonId = 1, CategoryId = 1},
                    new PokemonCategory { PokemonId = 2, CategoryId = 2 },
                    new PokemonCategory { PokemonId = 3, CategoryId = 3 }
            );

            // Seeding para a entidade PokemonOwner
            modelBuilder.Entity<PokemonOwner>().HasData(
                    new PokemonOwner { PokemonId = 1, OwnerId = 1 },
                    new PokemonOwner { PokemonId = 2, OwnerId = 2 },
                    new PokemonOwner { PokemonId = 3, OwnerId = 3 }
            );
        }
    }
}
