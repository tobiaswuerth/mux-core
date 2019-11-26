**Parts:** *[core](https://github.com/tobiaswuerth/mux-core)* | [data](https://github.com/tobiaswuerth/mux-data) | [cli](https://github.com/tobiaswuerth/mux-cli) | [www](https://github.com/tobiaswuerth/mux-www) | [api](https://github.com/tobiaswuerth/mux-api)

# mux-core

Available as [NuGet Package](https://www.nuget.org/packages/ch.wuerth.tobias.mux.Core/)

Contains 
* definitions
* utility classes
* base classes
* globally relevant things

-----

# The Mux Project
The main goal of this project is to allow for easy, fast and reliable work with large music libraries. 

**Note:**
This product is still work in progress and in a very early state. Not everything might work correnctly yet.

It consists of the following parts:

## CLI
CLI for library management coming with the following plugins (some might not be available yet):

Plugin name | Description
------------|----------------
Import | Crawls directory to find new files which then get imported into the database
Chromaprint | Calculates an acoustic fingerprint using the [AcoustID Chromaprint Project](https://github.com/acoustid/chromaprint)
AcoustID | Fetches MBIDs from the [AcoustID](https://acoustid.org/) web API with the generated Chromaprint fingerprint
MusicBrainz | Fetches meta data from the [MusicBrainz](https://musicbrainz.org/) web API for the fetched MBIDs of the AcoustID web API call
ExistanceChecker | Checkes if the indexed files in the database still exist physically on drive
... | ... (more will follow, ideas are welcome)

## Web API
Provides an REST API implementation as an interface to the database which can be used to build applications for.

## Web Player
A web player which allows the users to login and browse the files processed.

![search](https://dl.dropboxusercontent.com/s/cd52h38gy8aj1z5/i_view64_2019-11-26_21-12-10.png)
![ui](https://dl.dropboxusercontent.com/s/08488kssiec0cce/i_view64_2019-11-26_21-13-54.png)

The website is developed as progressive web app (PWA)
