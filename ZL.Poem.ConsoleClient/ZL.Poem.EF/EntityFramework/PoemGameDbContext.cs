using Abp.EntityFrameworkCore;
using Castle.MicroKernel.LifecycleConcerns;
using Microsoft.EntityFrameworkCore;
using ZL.Poem.Core.Poems;

namespace ZL.Poem.EF.EntityFramework
{
    public class PoemGameDbContext:AbpDbContext
    {
        //传入参数的类型，必须是DbContextOptions<PoemDbContext>
        public PoemGameDbContext(DbContextOptions<PoemGameDbContext> options) : base(options)
        {
        }
       
        public virtual  DbSet<Poet> Poets{get;set;}

         public virtual DbSet<Core.Poems.Poem> Poems { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<CategoryPoem> CategoryPoems { get; set; }

        /// <summary>
        ///     Override this method to further configure the model that was discovered by convention from the entity types
        ///     exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        ///     and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <remarks>
        ///     If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        ///     then this method will not be run.
        /// </remarks>
        /// <param name="modelBuilder">
        ///     The builder being used to construct the model for this context. Databases (and other extensions) typically
        ///     define extension methods on this object that allow you to configure aspects of the model that are specific
        ///     to a given database.
        /// </param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
             //映射Poet到数据库表
             modelBuilder.Entity<Poet>().ToTable("Poet");

             //属性名Id映射为PoetId
            modelBuilder.Entity<Poet>().Property(x=>x.Id).HasColumnName("PoetID");

             //Poem映射
            modelBuilder.Entity<Core.Poems.Poem>().ToTable("Poem");
            modelBuilder.Entity<Core.Poems.Poem>()
                    .Property(p => p.Id)
                    .HasColumnName("PoemId");

            //定义Poem与Poet之间的一对多关系
            modelBuilder.Entity<Core.Poems.Poem>().HasOne<Poet>(s => s.Author)
                    .WithMany(s => s.Poems)
                    .HasForeignKey(s => s.PoetID);

            //Category映射
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Category>().
               Property(p => p.Id)
               .HasColumnName("CategoryId");

            ///CategoryPoem映射
            modelBuilder.Entity<CategoryPoem>().ToTable("CategoryPoem");
            modelBuilder.Entity<CategoryPoem>().
               Property(p => p.Id)
               .HasColumnName("CategoryPoemId");

            //定义多对多关系
            modelBuilder.Entity<CategoryPoem>()
                        .HasKey(t => new { t.CategoryId, t.PoemId });

            modelBuilder.Entity<CategoryPoem>()
                .HasOne(pt => pt.Poem)
                .WithMany(p => p.PoemCategories)
                .HasForeignKey(pt => pt.PoemId);

            modelBuilder.Entity<CategoryPoem>()
                .HasOne(pt => pt.Category)
                .WithMany(t => t.CategoryPoems)
                .HasForeignKey(pt => pt.CategoryId);
        
        }
    }
}