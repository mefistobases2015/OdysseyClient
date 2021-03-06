﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;

namespace OdysseyDesktopClient
{
    class TagManager
    {
        public void setID3(Metadata pMetadata)
        {
            var taglibFile = TagLib.File.Create(pMetadata._SongDirectory);
            taglibFile.Tag.Title = pMetadata._ID3Title;
            string[] artists = {pMetadata._ID3Artist};
            taglibFile.Tag.Performers = artists;
            string[] genres = { pMetadata._ID3Genre };
            taglibFile.Tag.Genres = genres;
            taglibFile.Tag.Album = pMetadata._ID3Album;
            taglibFile.Tag.Comment = pMetadata._ID3Comment;
            taglibFile.Tag.Lyrics = pMetadata._ID3Lyrics;
            uint pYearParse = 0;
            uint.TryParse(pMetadata._ID3Year, out pYearParse);
            taglibFile.Tag.Year = pYearParse;
            taglibFile.Save();
        }

        public Metadata getID3ByDirectory(string pDirectory)
        {
            Metadata id3op = new Metadata();
            TagLib.File tagFile = TagLib.File.Create(pDirectory);
            List<string> p = new List<string>();
            id3op._SongDirectory = pDirectory;
            id3op._ID3Title = tagFile.Tag.Title;
            id3op._ID3Album = tagFile.Tag.Album;
            id3op._ID3Year = (tagFile.Tag.Year.ToString());
            id3op._ID3Comment = tagFile.Tag.Comment;
            id3op._ID3Lyrics = tagFile.Tag.Lyrics;
            if (tagFile.Tag.Genres.Length > 0)
            {
                id3op._ID3Genre = tagFile.Tag.Genres[0];
            }
            if (tagFile.Tag.Performers.Length > 0)
            {
                id3op._ID3Artist = tagFile.Tag.Performers[0];
            }
            return id3op;
        }
    }
}
