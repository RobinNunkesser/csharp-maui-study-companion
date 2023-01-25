using Italbytz.Adapters.Meal.OpenMensa;
using Italbytz.Infrastructure.OpenMensa;

namespace StudyCompanion.Infra.Tests;

public class DataSourceTests
{
    OpenMensaMealDataSource source;

    [SetUp]
    public void Setup()
    {
        source = new OpenMensaMealDataSource(35, DateTime.Now);
    }

    [Test]
    public async Task TestRetrieveAll()
    {
        try
        {
            var meals = await source.RetrieveAll();
            Assert.NotNull(meals);
        }
        catch (Exception ex)
        {
            Assert.True(ex is MensaClosedException || ex is NoMealsForDateException);
        }
    }



}

/* 26.01.
 [
  {
    "id": 280236,
    "name": "Gouda-Valess Schnitzel (A, A1, A4, C, G) an Rusticakarottengem\u00fcse und Pommes Twister (A, A1)",
    "notes": [
      "Men\u00fc ist vegetarisch",
      "mit Farbstoff (1)",
      "Glutenhaltiges Getreide (A)",
      "Weizen (A1)",
      "Hafer (A4)",
      "Eier (C)",
      "Milch/Milchzucker (Laktose) (G)"
    ],
    "prices": { "Studierende": 2.35, "Bedienstete": 4.9 },
    "category": "Aktion 1",
    "image": "//static.studentenwerk-dresden.de/bilder/mensen/studentenwerk-dresden-lieber-mensen-gehen.jpg",
    "url": "https://www.studentenwerk-dresden.de/mensen/speiseplan/details-280236.html"
  },
  {
    "id": 280237,
    "name": "Paniertes Schweineschnitzel mit Kartoffelkruste \u00fcberbacken (A, A1, C, G), dazu Djuvec-Reis und Salat (J)",
    "notes": [
      "enth\u00e4lt Schweinefleisch",
      "Glutenhaltiges Getreide (A)",
      "Weizen (A1)",
      "Eier (C)",
      "Milch/Milchzucker (Laktose) (G)",
      "Senf (J)"
    ],
    "prices": { "Studierende": 3.87, "Bedienstete": 7.03 },
    "category": "Fleisch/Fisch",
    "image": "//static.studentenwerk-dresden.de/bilder/mensen/studentenwerk-dresden-lieber-mensen-gehen.jpg",
    "url": "https://www.studentenwerk-dresden.de/mensen/speiseplan/details-280237.html"
  },
  {
    "id": 280238,
    "name": "Hausgemachte Tofufrikadelle mit braunen Zwiebeln (A, A1, F) mit scharfer Letschoso\u00dfe (J), dazu Kartoffel-Selleriep\u00fcree (G, I)",
    "notes": [
      "Men\u00fc ist vegetarisch",
      "mit Konservierungsstoff (2)",
      "mit Antioxydationsmittel (3)",
      "mit S\u00fc\u00dfungsmittel (9)",
      "Glutenhaltiges Getreide (A)",
      "Weizen (A1)",
      "Soja (F)",
      "Milch/Milchzucker (Laktose) (G)",
      "Sellerie (I)",
      "Senf (J)"
    ],
    "prices": { "Studierende": 3.79, "Bedienstete": 6.89 },
    "category": "Vegan",
    "image": "//static.studentenwerk-dresden.de/bilder/mensen/studentenwerk-dresden-lieber-mensen-gehen.jpg",
    "url": "https://www.studentenwerk-dresden.de/mensen/speiseplan/details-280238.html"
  },
  {
    "id": 280239,
    "name": "Cremige Pilzso\u00dfe (A, A1, F, G)",
    "notes": [
      "Men\u00fc ist vegetarisch",
      "Glutenhaltiges Getreide (A)",
      "Weizen (A1)",
      "Soja (F)",
      "Milch/Milchzucker (Laktose) (G)"
    ],
    "prices": { "Studierende": 2.76, "Bedienstete": 5.01 },
    "category": "Pasta",
    "image": "//static.studentenwerk-dresden.de/bilder/mensen/studentenwerk-dresden-lieber-mensen-gehen.jpg",
    "url": "https://www.studentenwerk-dresden.de/mensen/speiseplan/details-280239.html"
  },
  {
    "id": 280240,
    "name": "Handbrot mit Mais, Erbsen, Paprika und Schmelz, dazu Kr\u00e4uter-Dip (A, A1, F)",
    "notes": [
      "Men\u00fc ist vegan",
      "mit Farbstoff (1)",
      "Glutenhaltiges Getreide (A)",
      "Weizen (A1)",
      "Soja (F)"
    ],
    "prices": { "Studierende": 2.9, "Bedienstete": 5.27 },
    "category": "Ofenfrisch mit Foto 1",
    "image": "//static.studentenwerk-dresden.de/bilder/mensen/studentenwerk-dresden-lieber-mensen-gehen.jpg",
    "url": "https://www.studentenwerk-dresden.de/mensen/speiseplan/details-280240.html"
  },
  {
    "id": 280241,
    "name": "Handbrot mit Wiener W\u00fcrstchen, Bacon, roten Zwiebeln und Gouda, dazu Barbecue-Dip (A, A1, G)",
    "notes": [
      "enth\u00e4lt Schweinefleisch",
      "enth\u00e4lt Rindfleisch",
      "mit Konservierungsstoff (2)",
      "mit Antioxydationsmittel (3)",
      "mit Phosphat (8)",
      "Glutenhaltiges Getreide (A)",
      "Weizen (A1)",
      "Milch/Milchzucker (Laktose) (G)"
    ],
    "prices": { "Studierende": 2.9, "Bedienstete": 5.27 },
    "category": "Ofenfrisch mit Foto 2",
    "image": "//static.studentenwerk-dresden.de/bilder/mensen/studentenwerk-dresden-lieber-mensen-gehen.jpg",
    "url": "https://www.studentenwerk-dresden.de/mensen/speiseplan/details-280241.html"
  },
  {
    "id": 280291,
    "name": "Wurstgulasch (A, A1, J)",
    "notes": [
      "enth\u00e4lt Schweinefleisch",
      "enth\u00e4lt Rindfleisch",
      "mit Konservierungsstoff (2)",
      "mit Antioxydationsmittel (3)",
      "mit Phosphat (8)",
      "Glutenhaltiges Getreide (A)",
      "Weizen (A1)",
      "Senf (J)"
    ],
    "prices": { "Studierende": 2.76, "Bedienstete": 5.01 },
    "category": "Pasta",
    "image": "//static.studentenwerk-dresden.de/bilder/mensen/studentenwerk-dresden-lieber-mensen-gehen.jpg",
    "url": "https://www.studentenwerk-dresden.de/mensen/speiseplan/details-280291.html"
  }
]

 */
