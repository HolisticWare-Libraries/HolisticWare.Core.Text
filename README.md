# HolisticWare.Core.Text

[![Join the chat at https://gitter.im/HolisticWare-Core-Text/community](https://badges.gitter.im/HolisticWare-Core-Text/community.svg)](https://gitter.im/HolisticWare-Core-Text/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

|                                               |                                                                                                             |
|-----------------------------------------------|-------------------------------------------------------------------------------------------------------------|
| Build Library Source GitHub Actions           | ![https://github.com/holisticware/Holisticware.Core.Text/workflows/build-source/badge.svg](https://github.com/holisticware/Holisticware.Core.Text/workflows/build-source/badge.svg)                    |
| Build Library Source AzureDevOps Pipelines    |                                                                                                             |


Implementations are based on:

*   `string`

    *   `netstandard1.0`

    *   Implementation [INPROGRESS]

    *   Tests [INPROGRESS]

    *   performance bit hacks 

        *   https://twitter.com/badamczewski01/status/1465311107984379907

        *   some advanced bit-hacks, I have recorded two lectures that show some interesting ones:

            *   https://youtube.com/watch?v=Q_Apap8Dfbk

            *   https://youtube.com/watch?v=OPFJUpdCq0I

*   `Span<T>` and `Memory<T>` from `System.Memory`

    *   `netstandard1.1`

    *   Implementation [INPROGRESS]

    *   Tests [INPROGRESS]

*   https://github.com/secretGeek/AwesomeCSV

    *   https://github.com/22222/CsvTextFieldParser

Text utilities:

*   CharacterSeparatedValues
    
    *   CSV https://en.wikipedia.org/wiki/Comma-separated_values

    *   TSV https://en.wikipedia.org/wiki/Tabulator-separated_values

    *   DSV https://en.wikipedia.org/wiki/Delimiter-separated_values

*   CSV

    *   https://dfederm.com/learn-span-by-implementing-a-high-performance-csv-parser/

        *   https://github.com/dfederm/DelimiterSeparatedTextParser

*   Microformats

    *   http://microformats.org/

    *   https://en.wikipedia.org/wiki/Microformat


   https://en.wikipedia.org/wiki/VCard

   http://fileformats.archiveteam.org/wiki/Calendars

   http://fileformats.archiveteam.org/wiki/Electronic_File_Formats


## Multitargeting

*   https://github.com/xamarin/Essentials/blob/master/Xamarin.Essentials/Xamarin.Essentials.csproj



## Performance


*   https://stackoverflow.com/questions/8037070/whats-the-fastest-way-to-read-a-text-file-line-by-line

*   https://stackoverflow.com/questions/36420013/open-and-read-thousands-of-files-as-fast-as-possible

*   https://stackoverflow.com/questions/7387085/how-to-read-an-entire-file-to-a-string-using-c

*   https://cc.davelozinski.com/c-sharp/fastest-way-to-read-text-files

*   https://cc.davelozinski.com/c-sharp/the-fastest-way-to-read-and-process-text-files