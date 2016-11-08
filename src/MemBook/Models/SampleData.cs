using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Linq;

namespace MemBook.Models
{
    public static class SampleData
    {
        private static void createRoles(ApplicationDbContext context)
        {
            
            bool t = context.Roles.Contains(new IdentityRole { Name = "admin" });
            if (!t)
            {
                context.Roles.Add(new IdentityRole("admin"));
            }
            bool tt =  context.Roles.Contains(new IdentityRole { Name = "moderator" });
            if (!tt)
            {
                context.Roles.Add(new IdentityRole("moderator"));
            }
            bool ttt =  context.Roles.Contains(new IdentityRole { Name = "user" });
            if (!ttt)
            {
                context.Roles.Add(new IdentityRole("user"));
            }
        }
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
            createRoles(context);
            if (context != null && !context.Books.Any())
            {
                context.Books.AddRange(
                    new Book
                    {
                        Name = "Война и мир",
                        Company = "Толстой и жена",
                        Price = 600,
                        Annotation = "Хорошо известный классический роман-эпопея Льва Толстого рассказывает о сложном, бурном периоде в истории России и всей Европы — эпохе завоевательных походов "
                        + "\nимператора Наполеона в Восточную Европу и Россию, с 1805 по 1812 год. Автор подробно рассказывает о Войне — о ходе боевых действий от Аустерлица до Бородино и "
                        + "\nБерезины; и о Мире — показана жизнь в России в это же время, причем пером писателя охвачены все слои общества — дворянские семьи, крестьяне, горожане, солдаты и даже 0"
                        + "императоры.\nВ этом большом, многоплановом романе действуют десятки и сотни персонажей — и в их числе реальные исторические лица, при помощи которых Толстой старается "
                        + "\nизобразить жизнь в ту эпоху во всем ее многообразии. Часто автор отступает от основных событий романа и излагает свое мнение и взгляды по множеству вопросов — он говорит "
                        + "\nоб исторической науке, о социологии и психологии, морали и нравственности, свободе и необходимости."
                    },
                    new Book
                    {
                        Name = "Мемология",
                        Company = "Анонимус",
                        Price = 100500,
                        Annotation = "We are Anonymous. We are Legion. We do not forgive. We do not forget. Expect us"
                    },
                    new Book
                    {
                        Name = "Отцы и дети",
                        Company = "Ланит-ТурКом",
                        Price = 500,
                        Annotation = "Роман русского писателя Ивана Сергеевича Тургенева, написанный в 60-е годы XIX века. Роман стал знаковым для своего времени :)"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
