using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwissPost.StreetDirectory;
using SwissPost.StreetDirectory.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwissPost.StreetDirectoryTests
{
    [TestClass()]
    public class ProviderTests
    {
        private const string BasePath = @"..\..\..\..\..\..\swisspost-streetdirectory-data\";

        [TestMethod]
        public async Task Read_NEW_HEA_Test()
        {
            // Arrange
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            using var reader = new StreamReader(stream);

            writer.WriteLine("00;20200921;12448");
            writer.Flush();
            stream.Position = 0;


            // Act
            var provider = new Provider();
            var repository = await provider.Read(reader);


            // Assert
            repository.NEW_HEA.Should().NotBeNull();
            var actual = repository.NEW_HEA;
            actual.REC_ART.Should().Be("00");
            actual.VDAT.Should().Be(new DateTime(2020, 09, 21));
            actual.ZCODE.Should().Be("12448");
        }

        [TestMethod]
        public async Task Read_NEW_PLZ1_Test()
        {
            // Arrange
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            using var reader = new StreamReader(stream);

            writer.WriteLine("01;104;5586;20;1000;00;1000;Lausanne;Lausanne;VD;2;;130;19880301;100060;N");
            writer.WriteLine("01;105;5586;80;1000;01;1000;Lausanne 1 Dépôt;Lausanne 1 Dépôt;VD;2;;130;20050401;100060;");
            writer.Flush();
            stream.Position = 0;


            // Act
            var provider = new Provider();
            var repository = await provider.Read(reader);


            // Assert
            repository.NEW_PLZ1s.Should().HaveCount(2);

            var actual = repository.NEW_PLZ1s[104];
            actual.ONRP.Should().Be(104);
            actual.BFSNR.Should().Be(5586);
            actual.PLZ_TYP.Should().Be(20);
            actual.POSTCODE.Should().Be(1000);
            actual.PLZ_ZZ.Should().Be("00");
            actual.GPLZ.Should().Be(1000);
            actual.ORTBEZ18.Should().Be("Lausanne");
            actual.ORTBEZ27.Should().Be("Lausanne");
            actual.CANTON.Should().Be("VD");
            actual.LANGUAGECODE.Should().Be(LanguageCode.French);
            actual.SPRACHCODE_ABW.Should().BeNull();
            actual.BRIEFZ_DURCH.Should().Be(130);
            actual.GILT_AB_DAT.Should().Be(new DateTime(1988, 03, 01));
            actual.PLZ_BRIEFZUST.Should().Be(100060);
            actual.PLZ_COFF.Should().BeFalse();

            actual = repository.NEW_PLZ1s[105];
            actual.ONRP.Should().Be(105);
            actual.BFSNR.Should().Be(5586);
            actual.PLZ_TYP.Should().Be(80);
            actual.POSTCODE.Should().Be(1000);
            actual.PLZ_ZZ.Should().Be("01");
            actual.GPLZ.Should().Be(1000);
            actual.ORTBEZ18.Should().Be("Lausanne 1 Dépôt");
            actual.ORTBEZ27.Should().Be("Lausanne 1 Dépôt");
            actual.CANTON.Should().Be("VD");
            actual.LANGUAGECODE.Should().Be(LanguageCode.French);
            actual.SPRACHCODE_ABW.Should().BeNull();
            actual.BRIEFZ_DURCH.Should().Be(130);
            actual.GILT_AB_DAT.Should().Be(new DateTime(2005, 04, 01));
            actual.PLZ_BRIEFZUST.Should().Be(100060);
            actual.PLZ_COFF.Should().BeNull();
        }

        [TestMethod]
        public async Task Read_NEW_PLZ2_Test()
        {
            // Arrange
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            using var reader = new StreamReader(stream);

            writer.WriteLine("02;104;001;2;3;Losanna;Losanna");
            writer.WriteLine("02;125;001;2;2;Le Chalet-à-Gobet;Le Chalet-à-Gobet");
            writer.WriteLine("02;1088;002;3;2;Granges-Chât-d'Oex;Granges-près-Château-d'Oex");
            writer.Flush();
            stream.Position = 0;


            // Act
            var provider = new Provider();
            var repository = await provider.Read(reader);


            // Assert
            repository.NEW_PLZ2s.Should().HaveCount(3);

            // First
            var actual = repository.NEW_PLZ2s.Skip(0).First();
            actual.ONRP.Should().Be(104);
            actual.LAUFNUMMER.Should().Be(001);
            actual.BEZTYP.Should().Be(2);
            actual.SPRACHCODE.Should().Be(LanguageCode.Italian);
            actual.ORTBEZ18.Should().Be("Losanna");
            actual.ORTBEZ27.Should().Be("Losanna");

            // Second
            actual = repository.NEW_PLZ2s.Skip(1).First();
            actual.ONRP.Should().Be(125);
            actual.LAUFNUMMER.Should().Be(001);
            actual.BEZTYP.Should().Be(2);
            actual.SPRACHCODE.Should().Be(LanguageCode.French);
            actual.ORTBEZ18.Should().Be("Le Chalet-à-Gobet");
            actual.ORTBEZ27.Should().Be("Le Chalet-à-Gobet");

            // Third
            actual = repository.NEW_PLZ2s.Skip(2).First();
            actual.ONRP.Should().Be(1088);
            actual.LAUFNUMMER.Should().Be(002);
            actual.BEZTYP.Should().Be(3);
            actual.SPRACHCODE.Should().Be(LanguageCode.French);
            actual.ORTBEZ18.Should().Be("Granges-Chât-d'Oex");
            actual.ORTBEZ27.Should().Be("Granges-près-Château-d'Oex");
        }

        [TestMethod]
        public async Task Read_NEW_COM_Test()
        {
            // Arrange
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            using var reader = new StreamReader(stream);

            writer.WriteLine("03;420;Rüdtligen-Alchenflüh;BE;404");
            writer.WriteLine("03;6212;Dorénaz;VS;");
            writer.WriteLine("03;7101;Deutschland;DE;");
            writer.Flush();
            stream.Position = 0;


            // Act
            var provider = new Provider();
            var repository = await provider.Read(reader);


            // Assert
            repository.NEW_COMs.Should().HaveCount(3);

            // First
            var actual = repository.NEW_COMs.Values.Skip(0).First();
            actual.BFSNR.Should().Be(420);
            actual.GEMEINDENAME.Should().Be("Rüdtligen-Alchenflüh");
            actual.KANTON.Should().Be("BE");
            actual.AGGLONR.Should().Be(404);

            // Second
            actual = repository.NEW_COMs.Values.Skip(1).First();
            actual.BFSNR.Should().Be(6212);
            actual.GEMEINDENAME.Should().Be("Dorénaz");
            actual.KANTON.Should().Be("VS");
            actual.AGGLONR.Should().BeNull();

            // Third
            actual = repository.NEW_COMs.Values.Skip(2).First();
            actual.BFSNR.Should().Be(7101);
            actual.GEMEINDENAME.Should().Be("Deutschland");
            actual.KANTON.Should().Be("DE");
            actual.AGGLONR.Should().BeNull();
        }

        [TestMethod]
        public async Task Read_NEW_STR_Test()
        {
            // Arrange
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            using var reader = new StreamReader(stream);

            writer.WriteLine("04;30241;125;Vulliette, chemin de la;Vulliette, chemin de la;chemin de la Vulliette;chemin de la Vulliette;1;2;J;;");
            writer.WriteLine("04;30612;153;Antoine-Michel-Servan, av;Antoine-Michel-Servan, avenue;Av Antoine-Michel-Servan;Avenue Antoine-Michel-Servan;1;2;J;;");
            writer.WriteLine("04;15010889;163;EPFL;EPFL;EPFL;EPFL;2;2;J;N;");
            writer.Flush();
            stream.Position = 0;


            // Act
            var provider = new Provider();
            var repository = await provider.Read(reader);


            // Assert
            repository.NEW_STRs.Should().HaveCount(3);

            var actual = repository.NEW_STRs[30241];
            actual.Should().NotBeNull();
            actual.STRID.Should().Be(30241);
            actual.ONRP.Should().Be(125);
            actual.STRBEZK.Should().Be("Vulliette, chemin de la");
            actual.STRBEZL.Should().Be("Vulliette, chemin de la");
            actual.STRBEZ2K.Should().Be("chemin de la Vulliette");
            actual.STRBEZ2L.Should().Be("chemin de la Vulliette");
            actual.STR_LOK_TYP.Should().Be(StreetLocationType.StreetName);
            actual.STRBEZ_SPC.Should().Be(LanguageCode.French);
            actual.STRBEZ_COFF.Should().BeTrue();
            actual.STR_GANZFACH.Should().BeNull();
            actual.STR_FACH_ONRP.Should().BeNull();

            actual = repository.NEW_STRs[30612];
            actual.Should().NotBeNull();
            actual.STRID.Should().Be(30612);
            actual.ONRP.Should().Be(153);
            actual.STRBEZK.Should().Be("Antoine-Michel-Servan, av");
            actual.STRBEZL.Should().Be("Antoine-Michel-Servan, avenue");
            actual.STRBEZ2K.Should().Be("Av Antoine-Michel-Servan");
            actual.STRBEZ2L.Should().Be("Avenue Antoine-Michel-Servan");
            actual.STR_LOK_TYP.Should().Be(StreetLocationType.StreetName);
            actual.STRBEZ_SPC.Should().Be(LanguageCode.French);
            actual.STRBEZ_COFF.Should().BeTrue();
            actual.STR_GANZFACH.Should().BeNull();
            actual.STR_FACH_ONRP.Should().BeNull();

            actual = repository.NEW_STRs[15010889];
            actual.Should().NotBeNull();
            actual.STRID.Should().Be(15010889);
            actual.ONRP.Should().Be(163);
            actual.STRBEZK.Should().Be("EPFL");
            actual.STRBEZL.Should().Be("EPFL");
            actual.STRBEZ2K.Should().Be("EPFL");
            actual.STRBEZ2L.Should().Be("EPFL");
            actual.STR_LOK_TYP.Should().Be(StreetLocationType.BuildingName);
            actual.STRBEZ_SPC.Should().Be(LanguageCode.French);
            actual.STRBEZ_COFF.Should().BeTrue();
            actual.STR_GANZFACH.Should().BeFalse();
            actual.STR_FACH_ONRP.Should().BeNull();
        }

        [TestMethod]
        public async Task Read_NEW_STRA_Test()
        {
            // Arrange
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            using var reader = new StreamReader(stream);

            writer.WriteLine("05;76064588;26229;2;Caspar Emil Spörristrasse;Caspar Emil Spörristrasse;Caspar Emil Spörristrasse;Caspar Emil Spörristrasse;1;1");
            writer.WriteLine("05;76060070;33857;2;Jardins, route de la Cité;Jardins, route de la Cité-des-;Route de la Cité Jardins;Route de la Cité-des-Jardins;1;2");
            writer.Flush();
            stream.Position = 0;


            // Act
            var provider = new Provider();
            var repository = await provider.Read(reader);


            // Assert
            repository.NEW_STRAs.Should().HaveCount(2);

            var actual = repository.NEW_STRAs[76064588];
            actual.Should().NotBeNull();
            actual.STRID_ALT.Should().Be(76064588);
            actual.STRID.Should().Be(26229);
            actual.STRTYP.Should().Be(2);
            actual.STRBEZAK.Should().Be("Caspar Emil Spörristrasse");
            actual.STRBEZAL.Should().Be("Caspar Emil Spörristrasse");
            actual.STRBEZA2K.Should().Be("Caspar Emil Spörristrasse");
            actual.STRBEZA2L.Should().Be("Caspar Emil Spörristrasse");
            actual.STR_LOK_TYP.Should().Be(1);
            actual.STRBEZ_SPC.Should().Be(LanguageCode.German);

            actual = repository.NEW_STRAs[76060070];
            actual.Should().NotBeNull();
            actual.STRID_ALT.Should().Be(76060070);
            actual.STRID.Should().Be(33857);
            actual.STRTYP.Should().Be(2);
            actual.STRBEZAK.Should().Be("Jardins, route de la Cité");
            actual.STRBEZAL.Should().Be("Jardins, route de la Cité-des-");
            actual.STRBEZA2K.Should().Be("Route de la Cité Jardins");
            actual.STRBEZA2L.Should().Be("Route de la Cité-des-Jardins");
            actual.STR_LOK_TYP.Should().Be(1);
            actual.STRBEZ_SPC.Should().Be(LanguageCode.French);
        }

        [TestMethod]
        public async Task Read_NEW_GEB_Test()
        {
            // Arrange
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            using var reader = new StreamReader(stream);

            writer.WriteLine("06;142;16933;23;;J;J;6413");
            writer.WriteLine("06;171;16933;52;A;J;N;");
            writer.WriteLine("06;76498406;15065811;21;;J;N;");
            writer.Flush();
            stream.Position = 0;


            // Act
            var provider = new Provider();
            var repository = await provider.Read(reader);


            // Assert
            repository.NEW_GEBs.Should().HaveCount(3);

            var actual = repository.NEW_GEBs[142];
            actual.Should().NotBeNull();
            actual.HOUSEKEY.Should().Be(142);
            actual.STRID.Should().Be(16933);
            actual.HNR.Should().Be(23);
            actual.HNRA.Should().BeEmpty();
            actual.HNR_COFF.Should().BeTrue();
            actual.GANZFACH.Should().BeTrue();
            actual.FACH_ONRP.Should().Be(6413);

            actual = repository.NEW_GEBs[171];
            actual.Should().NotBeNull();
            actual.HOUSEKEY.Should().Be(171);
            actual.STRID.Should().Be(16933);
            actual.HNR.Should().Be(52);
            actual.HNRA.Should().Be("A");
            actual.HNR_COFF.Should().BeTrue();
            actual.GANZFACH.Should().BeFalse();
            actual.FACH_ONRP.Should().BeNull();

            actual = repository.NEW_GEBs[76498406];
            actual.Should().NotBeNull();
            actual.HOUSEKEY.Should().Be(76498406);
            actual.STRID.Should().Be(15065811);
            actual.HNR.Should().Be(21);
            actual.HNRA.Should().BeEmpty();
            actual.HNR_COFF.Should().BeTrue();
            actual.GANZFACH.Should().BeFalse();
            actual.FACH_ONRP.Should().BeNull();
        }

        [TestMethod]
        public async Task Read_NEW_GEBA_Test()
        {
            // Arrange
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            using var reader = new StreamReader(stream);

            writer.WriteLine("07;61705;7984;Ärztehaus Lützelmatt;2");
            writer.WriteLine("07;15321;8086332;Chalet Ankeblüemli;2");
            writer.Flush();
            stream.Position = 0;


            // Act
            var provider = new Provider();
            var repository = await provider.Read(reader);


            // Assert
            repository.NEW_GEBAs.Should().HaveCount(2);

            var actual = repository.NEW_GEBAs[61705];
            actual.Should().NotBeNull();
            actual.HAUSKEY_ALT.Should().Be(61705);
            actual.HAUSKEY.Should().Be(7984);
            actual.GEB_BEZ_ALT.Should().Be("Ärztehaus Lützelmatt");
            actual.GEBTYP.Should().Be(2);

            actual = repository.NEW_GEBAs[15321];
            actual.Should().NotBeNull();
            actual.HAUSKEY_ALT.Should().Be(15321);
            actual.HAUSKEY.Should().Be(8086332);
            actual.GEB_BEZ_ALT.Should().Be("Chalet Ankeblüemli");
            actual.GEBTYP.Should().Be(2);
        }

        [TestMethod]
        public async Task Read_NEW_BOT_B_Test()
        {
            // Arrange
            using var stream = new MemoryStream();
            using var writer = new StreamWriter(stream);
            using var reader = new StreamReader(stream);

            writer.WriteLine("08;205;603000;603060;117;20;200;");
            writer.WriteLine("08;492;603000;603060;118;10;1200;");
            writer.Flush();
            stream.Position = 0;


            // Act
            var provider = new Provider();
            var repository = await provider.Read(reader);


            // Assert
            repository.NEW_BOT_Bs.Should().HaveCount(2);

            // First
            var actual = repository.NEW_BOT_Bs.Skip(0).First();
            actual.HAUSKEY.Should().Be(205);
            actual.APLZ.Should().Be(603000);
            actual.BBZPLZ.Should().Be(603060);
            actual.BOTENBEZ.Should().Be(117);
            actual.ETAPPENNR.Should().Be(20);
            actual.LAUFNR.Should().Be(200);
            actual.NDEPOT.Should().BeEmpty();

            // Second
            actual = repository.NEW_BOT_Bs.Skip(1).First();
            actual.HAUSKEY.Should().Be(492);
            actual.APLZ.Should().Be(603000);
            actual.BBZPLZ.Should().Be(603060);
            actual.BOTENBEZ.Should().Be(118);
            actual.ETAPPENNR.Should().Be(10);
            actual.LAUFNR.Should().Be(1200);
            actual.NDEPOT.Should().BeEmpty();
        }


        [TestMethod]
        public async Task Read_All_From_Zip_20200707_Test()
        {
            // Arrange
            using var archive = ZipFile.OpenRead(@BasePath + @"Post_Adressdaten-20200707.zip");
            var entry = archive.Entries.Single(e => e.FullName.StartsWith("Post_Adressdaten") && e.FullName.EndsWith(".csv"));

            // The official documentation about the encoding states:
            // "UTF-8 files (separated by semicolons)" (see chapter "1.6 Data format")
            // This is wrong!
            // The actual encoding seems to be ISO-8859-1
            using var reader = new StreamReader(entry.Open(), Encoding.GetEncoding("ISO-8859-1"));
            var provider = new Provider();


            // Act
            var repository = await provider.Read(reader);


            // Assert
            repository.NEW_HEA.Should().NotBeNull();
            repository.NEW_PLZ1s.Should().HaveCount(5244);
            repository.NEW_PLZ2s.Should().HaveCount(2017);
            repository.NEW_COMs.Should().HaveCount(2216);
            repository.NEW_STRs.Should().HaveCount(168889);
            repository.NEW_STRAs.Should().HaveCount(27770);
            repository.NEW_GEBs.Should().HaveCount(1869828);
            repository.NEW_GEBAs.Should().HaveCount(49257);
            repository.NEW_BOT_Bs.Should().HaveCount(1869530);
            repository.NEW_GEB_COMs.Should().HaveCount(0);

            // Check if encoding is correct
            repository.NEW_COMs.Values.Count(r => r.GEMEINDENAME == "Löhningen").Should().Be(1);
            repository.NEW_COMs.Values.Count(r => r.GEMEINDENAME == "Gruyères").Should().Be(1);
            // We should find "Genève" multiple times
            repository.NEW_PLZ1s.Values.Count(r => r.ORTBEZ18.Contains("Genève")).Should().BeGreaterThan(0);
        }

        [TestMethod]
        public async Task Read_All_From_Zip_20200804_Test()
        {
            // Arrange
            using var archive = ZipFile.OpenRead(@BasePath + @"Post_Adressdaten-20200804.zip");
            var entry = archive.Entries.Single(e => e.FullName.StartsWith("Post_Adressdaten") && e.FullName.EndsWith(".csv"));

            // The official documentation about the encoding states:
            // "UTF-8 files (separated by semicolons)" (see chapter "1.6 Data format")
            // This is wrong!
            // The actual encoding seems to be ISO-8859-1
            using var reader = new StreamReader(entry.Open(), Encoding.GetEncoding("ISO-8859-1"));
            var provider = new Provider();


            // Act
            var repository = await provider.Read(reader);


            // Assert
            repository.NEW_HEA.Should().NotBeNull();
            repository.NEW_PLZ1s.Should().HaveCount(5248);
            repository.NEW_PLZ2s.Should().HaveCount(2017);
            repository.NEW_COMs.Should().HaveCount(2216);
            repository.NEW_STRs.Should().HaveCount(168868);
            repository.NEW_STRAs.Should().HaveCount(27793);
            repository.NEW_GEBs.Should().HaveCount(1870846);
            repository.NEW_GEBAs.Should().HaveCount(49358);
            repository.NEW_BOT_Bs.Should().HaveCount(1870552);
            repository.NEW_GEB_COMs.Should().HaveCount(0);

            // Check if encoding is correct
            repository.NEW_COMs.Values.Count(r => r.GEMEINDENAME == "Löhningen").Should().Be(1);
            repository.NEW_COMs.Values.Count(r => r.GEMEINDENAME == "Gruyères").Should().Be(1);
            // We should find "Genève" multiple times
            repository.NEW_PLZ1s.Values.Count(r => r.ORTBEZ18.Contains("Genève")).Should().BeGreaterThan(0);
        }

        [TestMethod]
        public async Task Read_All_From_Zip_20200908_Test()
        {
            // Arrange
            using var archive = ZipFile.OpenRead(@BasePath + "Post_Adressdaten-20200908.zip");
            var entry = archive.Entries.Single(e => e.FullName.StartsWith("Post_Adressdaten") && e.FullName.EndsWith(".csv"));

            // The official documentation about the encoding states:
            // "UTF-8 files (separated by semicolons)" (see chapter "1.6 Data format")
            // This is wrong!
            // The actual encoding seems to be ISO-8859-1
            using var reader = new StreamReader(entry.Open(), Encoding.GetEncoding("ISO-8859-1"));
            var provider = new Provider();


            // Act
            var repository = await provider.Read(reader);


            // Assert
            repository.NEW_HEA.Should().NotBeNull();
            repository.NEW_PLZ1s.Should().HaveCount(5250);
            repository.NEW_PLZ2s.Should().HaveCount(2017);
            repository.NEW_COMs.Should().HaveCount(2216);
            repository.NEW_STRs.Should().HaveCount(168864);
            repository.NEW_STRAs.Should().HaveCount(27847);
            repository.NEW_GEBs.Should().HaveCount(1872081);
            repository.NEW_GEBAs.Should().HaveCount(49386);
            repository.NEW_BOT_Bs.Should().HaveCount(1871787);
            repository.NEW_GEB_COMs.Should().HaveCount(0);

            // Check if encoding is correct
            repository.NEW_COMs.Values.Count(r => r.GEMEINDENAME == "Löhningen").Should().Be(1);
            repository.NEW_COMs.Values.Count(r => r.GEMEINDENAME == "Gruyères").Should().Be(1);
            // We should find "Genève" multiple times
            repository.NEW_PLZ1s.Values.Count(r => r.ORTBEZ18.Contains("Genève")).Should().BeGreaterThan(0);
        }
    }
}