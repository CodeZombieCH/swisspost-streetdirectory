# Swiss Post - Street Directory

[![Nuget](https://img.shields.io/nuget/v/SwissPost.StreetDirectory)](https://www.nuget.org/packages/SwissPost.StreetDirectory/)

EN: A .NET Standard class library for the "Street directory with sorting data" CSV file provided by the Swiss Post

DE: Eine .NET Standard Programmbibliothek für die "Strassenverzeichnis mit Sortierdaten" CSV Datei der Schweizerischen Post

FR: *Bibliothèque logicielle ... "Répertoire des rues avec données de tri" ... La Poste*

IT: *Libreria  ... "Stradario con dati di spartizione" ... La Posta*


## Data

Visit the [Address and geodata - Swiss Post](https://www.post.ch/en/customer-center/online-services/zopa/adress-und-geodaten/info) website and download the latest `Post_Adressdaten-<date>.zip` ZIP archive.


## Installation

Install the NuGet package.


## Usage



```csharp
using var archive = ZipFile.OpenRead(@"Post_Adressdaten-20200908.zip");
var entry = archive.Entries.Single(e => e.FullName.StartsWith("Post_Adressdaten") && e.FullName.EndsWith(".csv"));

// The official documentation about the encoding states:
// "UTF-8 files (separated by semicolons)" (see chapter "1.6 Data format")
// This is wrong!
// The actual encoding seems to be ISO-8859-1
using var reader = new StreamReader(entry.Open(), Encoding.GetEncoding("ISO-8859-1"));

var provider = new Provider();
var repository = await provider.Read(reader);

// Use the data from the repository, e.g.:
Console.WriteLine($"REC_ART: {repository.NEW_HEA.REC_ART}, VDAT: {repository.NEW_HEA.VDAT}, ZCODE: {repository.NEW_HEA.ZCODE}");
// Should print:
// REC_ART: 00, VDAT: 21.09.2020 00:00:00, ZCODE: 12448
```


## Encoding

Be aware that the encoding described by the official documentation is wrong.

```bash
$ file Post_Adressdaten20200908.csv
Post_Adressdaten20200908.csv: ISO-8859 text, with CRLF line terminators
```

If the documentation states:
 - `ASCII`, the actual encoding is `ISO-8859-1`
 - `UTF-8`, the actual encoding is `ISO-8859-1`

You can either read it as `ISO-8859-1` or convert the original file to `UTF-8`:

```bash
$ iconv -c -f ISO-8859-1 -t utf-8 Post_Adressdaten20200908.csv > Post_Adressdaten20200908.utf8.csv
```

## Scripts

Check out the `scripts/` directory for various scripts helping in dealing with the CSV file.
