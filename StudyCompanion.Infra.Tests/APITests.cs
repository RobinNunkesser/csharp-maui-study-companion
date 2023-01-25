using Italbytz.Infrastructure.OpenMensa;

namespace StudyCompanion.Infra.Tests;

public class APITests
{
    OpenMensaAPI api;

    [SetUp]
    public void Setup()
    {
        api = new OpenMensaAPI();
    }

    [Test]
    public async Task TestGetCanteens()
    {
        var canteens = await api.GetCanteens();
        Assert.IsTrue(canteens?.Count > 0);
    }

    [Test]
    public async Task TestGetCanteenDays()
    {
        var canteenDays = await api.GetCanteenDays(6);
        Assert.NotNull(canteenDays);
    }

    [Test]
    public async Task TestGetMeals()
    {
        try
        {
            var meals = await api.GetMeals(6, DateTime.Now);
            Assert.NotNull(meals);
        }
        catch (Exception ex)
        {
            Assert.True(ex is MensaClosedException || ex is NoMealsForDateException);
        }

    }

}

// 35, 4, 8

/* https://api.studentenwerk-dresden.de/openmensa/v2/canteens

[
  {
    "id": 6,
    "name": "Mensa Matrix",
    "city": "Dresden",
    "address": "Reichenbachstr. 1, 01069 Dresden",
    "coordinates": [51.034283226863565, 13.734020590782166],
    "url": "https://www.studentenwerk-dresden.de/mensen/details-mensa-matrix.html",
    "menu": "https://www.studentenwerk-dresden.de/mensen/speiseplan/mensa-matrix.html"
  },
  {
    "id": 35,
    "name": "Zeltschl\u00f6sschen",
    "city": "Dresden",
    "address": "N\u00fcrnberger Stra\u00dfe 55, 01187 Dresden",
    "coordinates": [51.031614756984816, 13.728645443916323],
    "url": "https://www.studentenwerk-dresden.de/mensen/details-zeltschloesschen.html",
    "menu": "https://www.studentenwerk-dresden.de/mensen/speiseplan/zeltschloesschen.html"
  },
  {
    "id": 4,
    "name": "Alte Mensa",
    "city": "Dresden",
    "address": "Mommsenstr. 13, 01069 Dresden",
    "coordinates": [51.02696733929933, 13.726491630077364],
    "url": "https://www.studentenwerk-dresden.de/mensen/details-alte-mensa.html",
    "menu": "https://www.studentenwerk-dresden.de/mensen/speiseplan/alte-mensa.html"
  },
  {
    "id": 8,
    "name": "Mensologie",
    "city": "Dresden",
    "address": "Blasewitzer Str. 84, 01307 Dresden",
    "coordinates": [51.052705307014044, 13.784312009811401],
    "url": "https://www.studentenwerk-dresden.de/mensen/details-mensologie.html",
    "menu": "https://www.studentenwerk-dresden.de/mensen/speiseplan/mensologie.html"
  },
  {
    "id": 9,
    "name": "Mensa Siedepunkt",
    "city": "Dresden",
    "address": "Zellescher Weg 17, 01069 Dresden",
    "coordinates": [51.02946063983054, 13.738727867603302],
    "url": "https://www.studentenwerk-dresden.de/mensen/details-mensa-siedepunkt.html",
    "menu": "https://www.studentenwerk-dresden.de/mensen/speiseplan/mensa-siedepunkt.html"
  },
  {
    "id": 32,
    "name": "Mensa Johannstadt",
    "city": "Dresden",
    "address": "Marschnerstra\u00dfe 38, 01307 Dresden",
    "coordinates": [51.053120073616405, 13.760884255170824],
    "url": "https://www.studentenwerk-dresden.de/mensen/details-mensa-johannstadt.html",
    "menu": "https://www.studentenwerk-dresden.de/mensen/speiseplan/mensa-johannstadt.html"
  },
  {
    "id": 10,
    "name": "Mensa TellerRandt",
    "city": "Tharandt",
    "address": "Pienner Stra\u00dfe 15, 01737 Tharandt",
    "coordinates": [50.98060093483648, 13.581464588642122],
    "url": "https://www.studentenwerk-dresden.de/mensen/details-mensa-tellerrandt.html",
    "menu": "https://www.studentenwerk-dresden.de/mensen/speiseplan/mensa-tellerrandt.html"
  },
  {
    "id": 29,
    "name": "Mensa U-Boot",
    "city": "Dresden",
    "address": "Mensa U-Boot im Potthoffbau Untergeschoss, George-B\u00e4hr-Stra\u00dfe/Hettnerstra\u00dfe 3, 01069 Dresden",
    "coordinates": [51.03030323712326, 13.72934550046921],
    "url": "https://www.studentenwerk-dresden.de/mensen/details-u-boot.html",
    "menu": "https://www.studentenwerk-dresden.de/mensen/speiseplan/u-boot.html"
  },
  {
    "id": 11,
    "name": "Mensa Palucca Hochschule",
    "city": "Dresden",
    "address": "Basteiplatz 4, 01277 Dresden",
    "coordinates": [51.02895, 13.770829],
    "url": "https://www.studentenwerk-dresden.de/mensen/details-mensa-palucca-hochschule.html",
    "menu": "https://www.studentenwerk-dresden.de/mensen/speiseplan/mensa-palucca-hochschule.html"
  },
  {
    "id": 33,
    "name": "Mensa WUeins",
    "city": "Dresden",
    "address": "Wundtstra\u00dfe 1, 01217 Dresden",
    "coordinates": [51.02990429156573, 13.748951107263567],
    "url": "https://www.studentenwerk-dresden.de/mensen/details-mensa-wueins.html",
    "menu": "https://www.studentenwerk-dresden.de/mensen/speiseplan/mensa-wueins.html"
  },
  {
    "id": 34,
    "name": "Mensa Br\u00fchl",
    "city": "Dresden",
    "address": "Br\u00fchlsche Terrasse 1, 01067 DresdenZugang \u00fcber den Innenhof der HfBK",
    "coordinates": [51.052948, 13.741935],
    "url": "https://www.studentenwerk-dresden.de/mensen/details-mensa-bruehl.html",
    "menu": "https://www.studentenwerk-dresden.de/mensen/speiseplan/mensa-bruehl.html"
  },
  {
    "id": 13,
    "name": "Mensa Stimm-Gabel",
    "city": "Dresden",
    "address": "Wettiner Platz 13, 01067 Dresden",
    "coordinates": [51.053722, 13.724652],
    "url": "https://www.studentenwerk-dresden.de/mensen/details-mensa-stimm-gabel.html",
    "menu": "https://www.studentenwerk-dresden.de/mensen/speiseplan/mensa-stimm-gabel.html"
  },
  {
    "id": 24,
    "name": "Mensa Kraatschn",
    "city": "Zittau",
    "address": "Hochwaldstr. 12, 02763 Zittau",
    "coordinates": [50.89042611030397, 14.804495573043825],
    "url": "https://www.studentenwerk-dresden.de/mensen/details-mensa-kraatschn.html",
    "menu": "https://www.studentenwerk-dresden.de/mensen/speiseplan/mensa-kraatschn.html"
  },
  {
    "id": 25,
    "name": "Mensa Mahlwerk",
    "city": "Zittau",
    "address": "Schwenninger Weg 1, 02763 Zittau",
    "coordinates": [50.88397255787832, 14.801915287971497],
    "url": "https://www.studentenwerk-dresden.de/mensen/details-mensa-mahlwerk.html",
    "menu": "https://www.studentenwerk-dresden.de/mensen/speiseplan/mensa-mahlwerk.html"
  },
  {
    "id": 28,
    "name": "MiO - Mensa im Osten",
    "city": "G\u00f6rlitz",
    "address": "Furtstra\u00dfe 1a, 02826 G\u00f6rlitz",
    "coordinates": [51.14924302208328, 14.998609721660616],
    "url": "https://www.studentenwerk-dresden.de/mensen/details-mio-mensa-im-osten.html",
    "menu": "https://www.studentenwerk-dresden.de/mensen/speiseplan/mio-mensa-im-osten.html"
  },
  {
    "id": 36,
    "name": "Grill Cube",
    "city": "Dresden",
    "address": "George-B\u00e4hr-Stra\u00dfe 1A-E, 01069 Dresden",
    "coordinates": [51.0285205, 13.7287076],
    "url": "https://www.studentenwerk-dresden.de/mensen/details-grill-cube.html",
    "menu": "https://www.studentenwerk-dresden.de/mensen/speiseplan/grill-cube.html"
  },
  {
    "id": 30,
    "name": "Mensa Sport",
    "city": "Dresden",
    "address": "Messering 2a, 01067 Dresden",
    "coordinates": [51.06903688508011, 13.71892511844635],
    "url": "https://www.studentenwerk-dresden.de/mensen/details-mensa-sport.html",
    "menu": "https://www.studentenwerk-dresden.de/mensen/speiseplan/mensa-sport.html"
  }
]

 
 */

/* https://api.studentenwerk-dresden.de/openmensa/v2/canteens/35/days/2023-01-23/meals

[
  {
    "id": 280219,
    "name": "Feuerfleisch vom Rind und Schwein mit Bohnen und Mais, dazu Erbsen und Kartoffelkroketten (C, G)",
    "notes": [
      "enth\u00e4lt Schweinefleisch",
      "enth\u00e4lt Rindfleisch",
      "mit Konservierungsstoff (2)",
      "Eier (C)",
      "Milch/Milchzucker (Laktose) (G)"
    ],
    "prices": { "Studierende": 3.87, "Bedienstete": 7.04 },
    "category": "Fleisch/Fisch",
    "image": "//bilderspeiseplan.studentenwerk-dresden.de/m35/202301/280219.jpg",
    "url": "https://www.studentenwerk-dresden.de/mensen/speiseplan/details-280219.html"
  },
  {
    "id": 280221,
    "name": "Paprika-Champignonrahmso\u00dfe mit Ajvar (A, A1)",
    "notes": [
      "Men\u00fc ist vegan",
      "Glutenhaltiges Getreide (A)",
      "Weizen (A1)"
    ],
    "prices": { "Studierende": 2.76, "Bedienstete": 5.01 },
    "category": "Pasta",
    "image": "//static.studentenwerk-dresden.de/bilder/mensen/studentenwerk-dresden-lieber-mensen-gehen.jpg",
    "url": "https://www.studentenwerk-dresden.de/mensen/speiseplan/details-280221.html"
  },
  {
    "id": 280222,
    "name": "Handbrot mit Bacon, Champignons und K\u00e4se gef\u00fcllt, dazu Kr\u00e4uterschmand (A, A1, G)",
    "notes": [
      "enth\u00e4lt Schweinefleisch",
      "mit Konservierungsstoff (2)",
      "mit Antioxydationsmittel (3)",
      "mit Phosphat (8)",
      "Glutenhaltiges Getreide (A)",
      "Weizen (A1)",
      "Milch/Milchzucker (Laktose) (G)"
    ],
    "prices": { "Studierende": 2.9, "Bedienstete": 5.27 },
    "category": "Ofenfrisch mit Foto 1",
    "image": "//static.studentenwerk-dresden.de/bilder/mensen/studentenwerk-dresden-lieber-mensen-gehen.jpg",
    "url": "https://www.studentenwerk-dresden.de/mensen/speiseplan/details-280222.html"
  },
  {
    "id": 280223,
    "name": "Handbrot mit Zucchini, getrockneten Tomaten und Hirtenk\u00e4se gef\u00fcllt, dazu Aioli (A, A1, G, L)",
    "notes": [
      "Men\u00fc ist vegetarisch",
      "enth\u00e4lt Knoblauch",
      "mit Antioxydationsmittel (3)",
      "Glutenhaltiges Getreide (A)",
      "Weizen (A1)",
      "Milch/Milchzucker (Laktose) (G)",
      "Sulfit/Schwefeldioxid (L)"
    ],
    "prices": { "Studierende": 2.9, "Bedienstete": 5.27 },
    "category": "Ofenfrisch mit Foto 2",
    "image": "//static.studentenwerk-dresden.de/bilder/mensen/studentenwerk-dresden-lieber-mensen-gehen.jpg",
    "url": "https://www.studentenwerk-dresden.de/mensen/speiseplan/details-280223.html"
  },
  {
    "id": 280288,
    "name": "Griechische Hackfleischso\u00dfe (A, A1, G)",
    "notes": [
      "enth\u00e4lt Schweinefleisch",
      "Glutenhaltiges Getreide (A)",
      "Weizen (A1)",
      "Milch/Milchzucker (Laktose) (G)"
    ],
    "prices": { "Studierende": 2.76, "Bedienstete": 5.01 },
    "category": "Pasta",
    "image": "//static.studentenwerk-dresden.de/bilder/mensen/studentenwerk-dresden-lieber-mensen-gehen.jpg",
    "url": "https://www.studentenwerk-dresden.de/mensen/speiseplan/details-280288.html"
  },
  {
    "id": 280337,
    "name": "Fr\u00fchlingsrollen (A, A1, F) mit Zapfenkroketten, (G,C ) Tomaten Dip ( J,F ) und Salat (J)",
    "notes": [
      "Men\u00fc ist vegetarisch",
      "enth\u00e4lt Knoblauch",
      "mit S\u00fc\u00dfungsmittel (9)",
      "Glutenhaltiges Getreide (A)",
      "Weizen (A1)",
      "Eier (C)",
      "Soja (F)",
      "Milch/Milchzucker (Laktose) (G)",
      "Senf (J)",
      "Sesam (K)"
    ],
    "prices": { "Studierende": 2.35, "Bedienstete": 4.9 },
    "category": "Aktion 1",
    "image": "//static.studentenwerk-dresden.de/bilder/mensen/studentenwerk-dresden-lieber-mensen-gehen.jpg",
    "url": "https://www.studentenwerk-dresden.de/mensen/speiseplan/details-280337.html"
  }
]

 
 */