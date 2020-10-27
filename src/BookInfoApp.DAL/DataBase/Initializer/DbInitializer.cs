using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookInfoApp.Core.Contracts;
using BookInfoApp.Core.Contracts.AreaBook;
using BookInfoApp.Core.Contracts.AreaBook.AreaAuthor;
using BookInfoApp.Core.Contracts.AreaBook.AreaGenre;
using BookInfoApp.Core.Contracts.AreaPublisher;
using BookInfoApp.Core.Entities;
using BookInfoApp.Core.Entities.AreaBook;
using BookInfoApp.Core.Entities.AreaBook.AreaAuthor;
using BookInfoApp.Core.Entities.AreaBook.AreaGenre;
using BookInfoApp.Core.Entities.AreaPublisher;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BookInfoApp.DAL.DataBase.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        public DbInitializer(IServiceScopeFactory serviceScopeProvider, IAuthorRepository authorRepository, IAgeCategoryRepository ageCategoryRepository, 
            IGenreRepository genreRepository, ICoverTypeRepository coverTypeRepository, IPublisherRepository publisherRepository, 
            IBookAuthorRepository bookAuthorRepository, IBookGenreRepository bookGenreRepository, IInputWorkRepository inputWorkRepository,
            IBookRepository bookRepository, IBookPublisherRepository bookPublisherRepository, ILogger<DbInitializer> logger)
        {
            this.serviceScopeProvider = serviceScopeProvider;
            this.authorRepository = authorRepository;
            this.ageCategoryRepository = ageCategoryRepository;
            this.coverTypeRepository = coverTypeRepository;
            this.publisherRepository = publisherRepository;
            this.genreRepository = genreRepository;
            this.bookAuthorRepository = bookAuthorRepository;
            this.bookGenreRepository = bookGenreRepository;
            this.inputWorkRepository = inputWorkRepository;
            this.bookRepository = bookRepository;
            this.bookPublisherRepository = bookPublisherRepository;
            this.logger = logger;
        }

        private readonly IServiceScopeFactory serviceScopeProvider;
        private readonly IAgeCategoryRepository ageCategoryRepository;
        private readonly IAuthorRepository authorRepository;
        private readonly ICoverTypeRepository coverTypeRepository;
        private readonly IPublisherRepository publisherRepository;
        private readonly IGenreRepository genreRepository;
        private readonly IBookAuthorRepository bookAuthorRepository;
        private readonly IBookGenreRepository bookGenreRepository;
        private readonly IInputWorkRepository inputWorkRepository;
        private readonly IBookRepository bookRepository;
        private readonly IBookPublisherRepository bookPublisherRepository;
        private readonly ILogger logger;
        public void InitializeAsync()
        {
            using (var serviceScope = serviceScopeProvider.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DbContextBookInfoApp>();
                context.Database.Migrate();

                var coverTypeListChack = coverTypeRepository.GetPageAsync(1, 20).Result;
                if (coverTypeListChack?.Count >0)
                    return;
                var authors = AuthorInit();
                var ageCategories= AgeCategoryInit();
                var genres=  GenreInit();
                var bookWorks = BookWorkInit(authors, ageCategories, genres);
                var books = BookInit(bookWorks, authors, ageCategories, genres);

                var coverTypes = CoverTypeInit();
                var publishers = PublisherInit();
                BookPublisherInit(books, coverTypes, publishers);
            }
        }

        private List<Book> BookInit(List<Book> bookWorks, List<Author> authors, 
            List<AgeCategory> ageCategories, List<Genre> genres)
        {
            var books = new List<Book>();

            books.Add(new Book
            {
                Name = "Мастер и Маргарита",
                AgeCategoryId = ageCategories[1].Id,
                YearOfWriting = 1940,
                Description =
                    "Жанровая уникальность «Мастера и Маргариты» не позволяет как-то однозначно определить булгаковский роман. Очень хорошо это подметил американский " +
                    "литературовед М. Крепе в своей книге «Булгаков и Пастернак как романисты: Анализ романов «Мастер и Маргарита» и «Доктор Живаго» (1984): «Роман " +
                    "Булгакова для русской литературы, действительно, в высшей степени новаторский, а потому и нелегко дающийся в руки. Только критик приближается к нему " +
                    "со старой стандартной системой мер, как оказывается, что кое-что так, а кое-что совсем не так. Фантастика наталкивается на сугубый реализм, миф на " +
                    "скрупулезную историческую достоверность, теософия на демонизм, романтика на клоунаду». Если добавить еще, что действие ершалаимских сцен «Мастера и " +
                    "Маргариты» — романа Мастера о Понтии Пилате происходит в течение одного дня, что удовлетворяет требованиям классицизма, то можно с уверенностью сказать, " +
                    "что в булгаковском романе соединились весьма органично едва ли не все существующие в мире жанры и литературные направления. Тем более, что достаточно " +
                    "распространены определения «Мастера и Маргариты» как романа символистского, постсимволистского или неоромантического. Кроме того, его вполне можно назвать и " +
                    "постреалистическим романом. С модернистской и постмодернистской, авангардистской литературой «Мастера и Маргариту» роднит то, что романную действительность, " +
                    "не исключая и современных московских глав, Булгаков строит почти исключительно на основе литературных источников, а инфернальная фантастика глубоко проникает " +
                    "в советский быт."
            });
            books.Add(new Book
            {
                Name = "12 стульев. Золотой теленок (сборник)",
                AgeCategoryId = ageCategories[0].Id,
                YearOfWriting = 2007,
                Description = "Что-то со мной не так, не нравятся мне культовые и легендарные вещи и ничего с этим поделать не могу. Так и знала, что буду разочарована... Вокруг Остапа " +
                              "Бендера целый культ образовался, все его знают, постоянно слышу как с данным героем сравнивают людей (ладно, не постоянно конечно, но на слуху имя точно). " +
                              "Что в нем особенного, не пойму, неужели мало обаятельных аферистов как вокруг нас, как в жизни, так и в художественной литературе? Думаю сюжет вообще нет " +
                              "смысла пересказывать, несмотря на то, что я фильм не смотрела, а книгу вот только дочитала, я знала сюжет, без подробностей, но все-таки ключевые моменты " +
                              "известны, наверное, каждому. Юмор... ох уж этот юмор, странно, никогда не считала себя без чувства юмора, но последнее время все сложнее и сложнее становиться " +
                              "адекватно реагировать на определенные виды юмора, это касается всех областей жизни. Почему-то юмор в качественной научно-популярной литературе (а его, как не " +
                              "странно, в таковой много), меня впечатляет намного больше чем в подобных саркастичных произведениях. Как известно, нас больше всего бесит то чего нам не " +
                              "хватает или то, чего в нас в избытке, в моем случае глупость, наглость и невежество бесят потому что мне их не хватает (надеюсь что я права). Я прям завидую " +
                              "тем кто способен вести себя так как герои книги и не чувствовать при этом угрызений совести."
            });


            books.Add(new Book
            {
                Name = "Братья Карамазовы",
                AgeCategoryId = ageCategories[0].Id,
                YearOfWriting = 1880,
                Description = "\"Братья Карамазовы\" — последний роман Ф. М. Достоевского, который автор писал два года. Роман был напечатан частями в Русском вестнике. " +
                              "Достоевский задумывал роман как первую часть эпического романа \"История Великого грешника\". Роман затрагивает глубокие вопросы о Боге, свободе, морали."
            });


            books.Add(new Book
            {
                Name = "Собачье сердце",
                AgeCategoryId = ageCategories[1].Id,
                YearOfWriting = 1925,
                Description = "Добрейший профессор Филипп Филиппович Преображенский проводит эксперимент по очеловечению милого пса Шарика. Однако эксперимент оканчивается провалом. " +
                              "Шарик воспринимает только худшие черты своего донора, пьяницы и хулигана пролетария Клима Чугункина. Вместо доброго пса возникает зловещий, тупой и " +
                              "агрессивный Полиграф Полиграфович Шариков, который, тем не менее, великолепно вписывается в социалистическую действительность и даже делает завидную " +
                              "карьеру: от существа неопределенного социального статуса до начальника подотдела очистки Москвы от бродячих животных. Превратив своего героя в " +
                              "начальника подотдела Московского Коммунального Хозяйства, Булгаков недобрым словом поминал свою вынужденную службу во владикавказском подотделе " +
                              "искусств и московском Лито (литературном отделе Главполитпросвета). Шариков становится общественно опасен, науськиваемый председателем домкома Швондером " +
                              "против своего создателя — профессора Преображенского, пишет доносы на него, а в конце даже грозит револьвером."
            });

            books.Add(new Book
            {
                Name = "Преступление и наказание",
                AgeCategoryId = ageCategories[1].Id,
                YearOfWriting = 1866,
                Description = "«Преступление и наказание» — социально-психологический и социально-философский роман Фёдора Михайловича Достоевского, над которым писатель работал " +
                              "в 1865—1866 годах. Впервые опубликован в 1866 году в журнале «Русский вестник». Через год вышло в свет отдельное издание, структура которого была немного " +
                              "изменена по сравнению с журнальной редакцией; кроме того, автор внёс в книжный вариант ряд сокращений и стилистических правок."
            });

            books.Add(new Book
            {
                Name = "Анна Каренина",
                AgeCategoryId = ageCategories[0].Id,
                YearOfWriting = 1877,
                Description = "«Анна Каренина» — лучший роман о женщине, написанный в XIX веке. По словам Ф. М. Достоевского, «Анна Каренина» поразила современников «не только вседневностью " +
                              "содержания, но и огромной психологической разработкой души человеческой, страшной глубиной и силой». Уже к началу 1900-х годов роман Толстого был переведен " +
                              "на многие языки мира, а в настоящее время входит в золотой фонд мировой литературы."
            });
            
            books.Add(new Book
            {
                Name = "Отцы и дети",
                AgeCategoryId = ageCategories[0].Id,
                YearOfWriting = 1861,
                Description = "Отцы и дети - роман русского писателя Ивана Сергеевича Тургенева (1818-1883), написанный в 60-е годы XIX века. Роман стал знаковым для своего времени, а образ " +
                              "главного героя Евгения Базарова был воспринят молодёжью как пример для подражания. Такие идеалы, как бескомпромиссность, отсутствие преклонения перед " +
                              "авторитетами и старыми истинами, приоритет полезного над прекрасным, были восприняты людьми того времени и нашли отражение в мировоззрении Базарова."
            });
            
            books.Add(new Book
            {
                Name = "Война и мир",
                AgeCategoryId = ageCategories[0].Id,
                YearOfWriting = 1869,
                Description = "Величайшая эпопея, снискавшая славу во всем мире. Сотни героев, застигнутых безжалостным потоком времени, и сотни судеб, перемолотых масштабными историческими " +
                              "событиями. Сменяются поколения и эпохи, а чтение \"Войны и мира\" по-прежнему дарит нам восторг познания простых и сложных жизненных истин. Мы все так же "+
                              "находим себя в Наташе Ростовой, Андрее Болконском, Пьере Безухове, все так же, подобно им, хотим жить, любить и верить наперекор войне – с неприятелем ли, " +
                              "с обстоятельствами или с самими собой."
            });
            
            books.Add(new Book
            {
                Name = "Евгений Онегин",
                AgeCategoryId = ageCategories[1].Id,
                YearOfWriting = 1831,
                Description = "“Евгений Онегин” — первое произведение в истории русской литературы, в котором автору удалось создать широчайшую панораму действительности, раскрыть " +
                              "важнейшие проблемы своего времени. В огромном зеркале романа читатели узнали жгучую современность, себя и своих знакомых, деревню, город и столицу, " +
                              "помещиков и крепостных. Они услышали живую разговорную, искреннюю речь лучшего из своих современников. За широкий охват жизненных тем, за глубину и " +
                              "точную передачу исторических деталей В. Г. Белинский назвал роман “Евгений Онегин” энциклопедией русской жизни и в высшей степени народным произведением."
            });

            books.Add(new Book
            {
                Name = "Капитанская дочка",
                AgeCategoryId = ageCategories[0].Id,
                YearOfWriting = 1836,
                Description = "Исторический роман (не повесть) А. С. Пушкина, действие которой происходит во время восстания Емельяна Пугачёва."
            });

            SaveeOperation(books, bookRepository);

            var bookAuthors = new List<BookAuthor>();
            bookAuthors.Add(new BookAuthor { AuthorId = authors[0].Id, BookId = books[0].Id, IsMain = true });//Мастер и Маргарита
            bookAuthors.Add(new BookAuthor { AuthorId = authors[1].Id, BookId = books[1].Id, IsMain = true });//12 стульев. Золотой теленок (сборник)
            bookAuthors.Add(new BookAuthor { AuthorId = authors[2].Id, BookId = books[1].Id });
            bookAuthors.Add(new BookAuthor { AuthorId = authors[3].Id, BookId = books[2].Id, IsMain = true });//Братья Карамазовы
            bookAuthors.Add(new BookAuthor { AuthorId = authors[0].Id, BookId = books[3].Id, IsMain = true });//Собачье сердце
            bookAuthors.Add(new BookAuthor { AuthorId = authors[3].Id, BookId = books[4].Id, IsMain = true });//Преступление и наказание
            bookAuthors.Add(new BookAuthor { AuthorId = authors[4].Id, BookId = books[5].Id, IsMain = true });//Анна Каренина
            bookAuthors.Add(new BookAuthor { AuthorId = authors[5].Id, BookId = books[6].Id, IsMain = true });//Отцы и дети
            bookAuthors.Add(new BookAuthor { AuthorId = authors[4].Id, BookId = books[7].Id, IsMain = true });//Война и мир
            bookAuthors.Add(new BookAuthor { AuthorId = authors[6].Id, BookId = books[8].Id, IsMain = true });//Евгений Онегин
            bookAuthors.Add(new BookAuthor { AuthorId = authors[6].Id, BookId = books[9].Id, IsMain = true });//Капитанская дочка

            SaveeOperation(bookAuthors, bookAuthorRepository);

            var bookGenres = new List<BookGenre>();
            bookGenres.Add(new BookGenre { GenreId = genres[6].Id, BookId = books[0].Id });//Мастер и Маргарита
            bookGenres.Add(new BookGenre { GenreId = genres[3].Id, BookId = books[0].Id });
            bookGenres.Add(new BookGenre { GenreId = genres[7].Id, BookId = books[0].Id });
            bookGenres.Add(new BookGenre { GenreId = genres[6].Id, BookId = books[1].Id });//12 стульев. Золотой теленок (сборник)
            bookGenres.Add(new BookGenre { GenreId = genres[3].Id, BookId = books[1].Id });
            bookGenres.Add(new BookGenre { GenreId = genres[5].Id, BookId = books[1].Id });
            bookGenres.Add(new BookGenre { GenreId = genres[3].Id, BookId = books[2].Id });//Братья Карамазовы
            bookGenres.Add(new BookGenre { GenreId = genres[4].Id, BookId = books[2].Id });
            bookGenres.Add(new BookGenre { GenreId = genres[3].Id, BookId = books[3].Id });//Собачье сердце
            bookGenres.Add(new BookGenre { GenreId = genres[4].Id, BookId = books[3].Id });
            bookGenres.Add(new BookGenre { GenreId = genres[6].Id, BookId = books[3].Id });
            bookGenres.Add(new BookGenre { GenreId = genres[3].Id, BookId = books[4].Id });//Преступление и наказание
            bookGenres.Add(new BookGenre { GenreId = genres[4].Id, BookId = books[4].Id });
            bookGenres.Add(new BookGenre { GenreId = genres[3].Id, BookId = books[5].Id });//Анна Каренина
            bookGenres.Add(new BookGenre { GenreId = genres[4].Id, BookId = books[5].Id });
            bookGenres.Add(new BookGenre { GenreId = genres[3].Id, BookId = books[6].Id });//Отцы и дети
            bookGenres.Add(new BookGenre { GenreId = genres[4].Id, BookId = books[6].Id });
            bookGenres.Add(new BookGenre { GenreId = genres[0].Id, BookId = books[7].Id });//Война и мир
            bookGenres.Add(new BookGenre { GenreId = genres[3].Id, BookId = books[7].Id });
            bookGenres.Add(new BookGenre { GenreId = genres[4].Id, BookId = books[7].Id });
            bookGenres.Add(new BookGenre { GenreId = genres[2].Id, BookId = books[8].Id });//Евгений Онегин
            bookGenres.Add(new BookGenre { GenreId = genres[3].Id, BookId = books[8].Id });
            bookGenres.Add(new BookGenre { GenreId = genres[4].Id, BookId = books[8].Id });
            bookGenres.Add(new BookGenre { GenreId = genres[0].Id, BookId = books[9].Id });//Капитанская дочка
            bookGenres.Add(new BookGenre { GenreId = genres[3].Id, BookId = books[9].Id });
            bookGenres.Add(new BookGenre { GenreId = genres[4].Id, BookId = books[9].Id });

            SaveeOperation(bookGenres, bookGenreRepository);

            var inputWorks = new List<InputWork>();
            inputWorks.Add(new InputWork { BookId = books[1].Id, WorkId = bookWorks[0].Id });
            inputWorks.Add(new InputWork { BookId = books[1].Id, WorkId = bookWorks[1].Id });

            SaveeOperation(inputWorks, inputWorkRepository);
            logger.LogTrace("Сохранение книг");
            return books;
        }

        private List<Book> BookWorkInit(List<Author> authors, List<AgeCategory> ageCategories, List<Genre> genres)
        {
            var books = new List<Book>();

            books.Add(new Book
            {
                Name = "Двенадцать стульев", 
                AgeCategoryId = ageCategories[0].Id, 
                YearOfWriting = 1928,
                Description =
                    "Бывший богач, светский лев и «предводитель дворянства» Ипполит Воробьянинов после революции стал обычным " +
                    "делопроизводителем ЗАГСа в маленьком городе. Он не забыл еще своих прежних привычек и часто грезит о былой жизни. " +
                    "Однажды размеренный ход жизни оказывается нарушен — умирающая теща поведала Воробьянинову об огромном богатстве, во " +
                    "время революции спрятанном ею в один из стульев гостиного гарнитура. Он тут же бросается на поиски, вместе со встреченным им " +
                    "«великим комбинатором», мошенником и любителем денежных знаков Остапом Бендером. Сокровище найти будет нелегко, но обуянные страстью " +
                    "к богатству Бендер и Воробьянинов не остановятся ни перед чем..."
            });
            books.Add(new Book
            {
                Name = "Золотой телёнок",
                AgeCategoryId = ageCategories[0].Id,
                YearOfWriting = 1931,
                Description = "В основе сюжета — дальнейшие приключения центрального персонажа \"Двенадцати стульев\" Остапа Бендера, происходящие на фоне картин " +
                              "советской жизни начала 1930-х годов. Жанр — плутовской роман, социальная сатира, роман-фельетон."
            });

            SaveeOperation(books, bookRepository);

            var bookAuthors = new List<BookAuthor>();
            bookAuthors.Add(new BookAuthor { AuthorId = authors[1].Id, BookId = books[0].Id, IsMain = true});
            bookAuthors.Add(new BookAuthor { AuthorId = authors[2].Id, BookId = books[0].Id });
            bookAuthors.Add(new BookAuthor { AuthorId = authors[1].Id, BookId = books[1].Id, IsMain = true});
            bookAuthors.Add(new BookAuthor { AuthorId = authors[2].Id, BookId = books[1].Id });

            SaveeOperation(bookAuthors, bookAuthorRepository);

            var bookGenres = new List<BookGenre>();
            bookGenres.Add(new BookGenre { GenreId = genres[6].Id, BookId = books[0].Id });
            bookGenres.Add(new BookGenre { GenreId = genres[3].Id, BookId = books[0].Id });
            bookGenres.Add(new BookGenre { GenreId = genres[5].Id, BookId = books[0].Id });
            bookGenres.Add(new BookGenre { GenreId = genres[6].Id, BookId = books[1].Id });
            bookGenres.Add(new BookGenre { GenreId = genres[3].Id, BookId = books[1].Id });

            SaveeOperation(bookGenres, bookGenreRepository);

            logger.LogTrace("Сохранение произведений");
            return books;
        }

        private List<Author> AuthorInit()
        {
            var authors = new List<Author>();

            authors.Add(new Author { SurName = "Булгаков", FirstName = "Михаил", MiddleName = "Афанасьевич" });
            authors.Add(new Author { SurName = "Ильф", FirstName = "Илья", MiddleName = "Арнольдович" });
            authors.Add(new Author { SurName = "Катаев", FirstName = "Евгений", MiddleName = "Петрович" });
            authors.Add(new Author { SurName = "Достоевский", FirstName = "Фёдор", MiddleName = "Михайлович" });
            authors.Add(new Author { SurName = "Толстой", FirstName = "Лев", MiddleName = "Николаевич" });
            authors.Add(new Author { SurName = "Тургенев", FirstName = "Иван", MiddleName = "Сергеевич" });
            authors.Add(new Author { SurName = "Пушкин", FirstName = "Александр", MiddleName = "Сергеевич" });

            SaveeOperation(authors, authorRepository);
            logger.LogTrace("Сохранение писателей");
            return authors;
        }

        private List<AgeCategory> AgeCategoryInit()
        {
            var ageCategories = new List<AgeCategory>();
            ageCategories.Add(new AgeCategory { AgeBegin = 12 });
            ageCategories.Add(new AgeCategory { AgeBegin = 16 });

            SaveeOperation(ageCategories, ageCategoryRepository);
            logger.LogTrace("Сохранение ограничение по возрасту");
            return ageCategories;
        }
        private List<Genre> GenreInit()
        {
            var genres = new List<Genre>();

            genres.Add(new Genre { Name = "Роман" }); 
            genres.Add(new Genre { Name = "Повесть" });
            genres.Add(new Genre { Name = "Стихи и поэзия" });
            genres.Add(new Genre { Name = "Русская классика" });
            genres.Add(new Genre { Name = "Русская литература" });
            genres.Add(new Genre { Name = "Юмор и сатира" });
            genres.Add(new Genre { Name = "Советская литература" });
            genres.Add(new Genre { Name = "Мистика" });
            
            SaveeOperation(genres, genreRepository);
            logger.LogTrace("Сохранение жанров");
            return genres;
        }

        private void BookPublisherInit(List<Book> books, List<CoverType> coverTypes, List<Publisher> publishers)
        {
            var bookPublishers = new List<BookPublisher>();
            bookPublishers.Add(new BookPublisher { BookId = books[0].Id, CoverTypeId = coverTypes[1].Id, PublisherId = publishers[0].Id, YearOfPublishing = 2012, TotalPage = 416 });
            bookPublishers.Add(new BookPublisher { BookId = books[1].Id, CoverTypeId = coverTypes[0].Id, PublisherId = publishers[1].Id, YearOfPublishing = 2017, TotalPage = 640 });
            bookPublishers.Add(new BookPublisher { BookId = books[2].Id, CoverTypeId = coverTypes[1].Id, PublisherId = publishers[0].Id, YearOfPublishing = 2012, TotalPage = 1056 });
            bookPublishers.Add(new BookPublisher { BookId = books[3].Id, CoverTypeId = coverTypes[0].Id, PublisherId = publishers[2].Id, YearOfPublishing = 2019, TotalPage = 480 });
            bookPublishers.Add(new BookPublisher { BookId = books[4].Id, CoverTypeId = coverTypes[1].Id, PublisherId = publishers[0].Id, YearOfPublishing = 2012, TotalPage = 672 });
            bookPublishers.Add(new BookPublisher { BookId = books[5].Id, CoverTypeId = coverTypes[2].Id, PublisherId = publishers[0].Id, YearOfPublishing = 2012, TotalPage = 960 });
            bookPublishers.Add(new BookPublisher { BookId = books[6].Id, CoverTypeId = coverTypes[1].Id, PublisherId = publishers[1].Id, YearOfPublishing = 2013, TotalPage = 288 });
            bookPublishers.Add(new BookPublisher { BookId = books[7].Id, CoverTypeId = coverTypes[0].Id, PublisherId = publishers[0].Id, YearOfPublishing = 2019, TotalPage = 1360 });
            bookPublishers.Add(new BookPublisher { BookId = books[8].Id, CoverTypeId = coverTypes[1].Id, PublisherId = publishers[2].Id, YearOfPublishing = 2015, TotalPage = 224 });
            bookPublishers.Add(new BookPublisher { BookId = books[9].Id, CoverTypeId = coverTypes[2].Id, PublisherId = publishers[1].Id, YearOfPublishing = 2017, TotalPage = 224 });

            SaveeOperation(bookPublishers, bookPublisherRepository);
            logger.LogTrace("Сохранение изданий книг");
        }

        private List<CoverType> CoverTypeInit()
        {
            var coverTypes = new List<CoverType>();

            coverTypes.Add(new CoverType { Name = "Твердый переплет" });
            coverTypes.Add(new CoverType { Name = "Мягкий переплет" });
            coverTypes.Add(new CoverType { Name = "Переплет ручной работы" });

            SaveeOperation(coverTypes, coverTypeRepository);
            logger.LogTrace("Сохранение тип обложки");
            return coverTypes;
        }
        private List<Publisher> PublisherInit()
        {
            var publishers = new List<Publisher>();

            publishers.Add(new Publisher { Name = "Эксмо" });
            publishers.Add(new Publisher { Name = "Арка" });
            publishers.Add(new Publisher { Name = "Время" });

            SaveeOperation(publishers, publisherRepository);
            logger.LogTrace("Сохранение изданий");
            return publishers;
        }


        private void SaveeOperation<TEntity>(List<TEntity> entities, IRepository<TEntity> repository)
            where TEntity : class, IEntity
        {
            for (int i = 0; i < entities.Count; i++)
            {
                repository.Create(entities[i]);
            }

            repository.Save();
        }

        private void SaveeOperation<TEntity, TId>(List<TEntity> entities, IRepository<TEntity, TId> repository)
            where TEntity : class, IEntity<TId>
            where TId : IEquatable<TId>
        {
            for (int i = 0; i < entities.Count; i++)
            {
                repository.Create(entities[i]);
            }

            repository.Save();
        }
    }
}
