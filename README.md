# DSC.ParseTorrentName
A .NET port of [celement-escolano](https://github.com/clement-escolano)'s [parse-torrent-title](https://github.com/clement-escolano/parse-torrent-title)!

This package is used to help you extract information from a torrent's file name. You can extract information such as title, resolution, audio, language, etc.

There is also support for registering your own handler(s) to the parser to extract more information!

## Installation
Use the following command to install ParseTorrentName, or install it from the NuGet Package Manager within Visual Studio.

    Install-Package DSC.ParseTorrentName

## Usage
Usage of the library is relatively straightforward. You can call `Parser.Default.Parse(fileName)` to get started right away! This will return a collection that with the information that was able to be extracted from the file name. 
```cs
var fileDetails = DSC.ParseTorrentName.Parser.Default.Parse("Color.Of.Night.Unrated.DC.VostFR.BRrip.x264");
// unrated = True
// source = brrip
// codec = x264
// language = vostfr
// title = Color Of Night
```

### Example
An example for getting details about a file name:
```cs
var fileDetails = Parser.Default.Parse("2019 After The Fall Of New York 1983 REMASTERED BDRip x264-GHOULS");
var title = fileDetails[DefaultHandlerNames.Title]; // 2019 After The Fall Of New York
var source = fileDetails[DefaultHandlerNames.Source]; // bdrip
var year = fileDetails[DefaultHandlerNames.Year]; // 1983
var codec = fileDetails[DefaultHandlerNames.Codec]; // x264
var remastered = fileDetails[DefaultHandlerNames.Remastered]; // True
var group = fileDetails[DefaultHandlerNames.Group]; // GHOULS
```

## License
[MIT](https://github.com/DSC-bdavis/DSC.ParseTorrentName/blob/master/LICENSE.txt)