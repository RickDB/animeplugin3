﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MyAnimePlugin3.ImageManagement;

namespace MyAnimePlugin3.ViewModel
{
	public class AniDB_SeiyuuVM
	{
		public int AniDB_SeiyuuID { get; set; }
		public int SeiyuuID { get; set; }
		public string SeiyuuName { get; set; }
		public string PicName { get; set; }


		public string PosterPathPlain
		{
			get
			{
				if (string.IsNullOrEmpty(PicName)) return "";

				return Path.Combine(Utils.GetAniDBCreatorImagePath(SeiyuuID), PicName);
			}
		}

		public string PosterPath
		{
			get
			{
				if (string.IsNullOrEmpty(PosterPathPlain)) return PosterPathPlain;

				if (!File.Exists(PosterPathPlain))
				{
					ImageDownloadRequest req = new ImageDownloadRequest(ImageEntityType.AniDB_Creator, this, false);
					MainWindow.imageHelper.DownloadImage(req);
					if (File.Exists(PosterPathPlain)) return PosterPathPlain;
				}

				return PosterPathPlain;
			}
		}

		public AniDB_SeiyuuVM(JMMServerBinary.Contract_AniDB_Seiyuu details)
		{
			if (details == null) return;

			this.AniDB_SeiyuuID = details.AniDB_SeiyuuID;
			this.SeiyuuID = details.SeiyuuID;
			this.SeiyuuName = details.SeiyuuName;
			this.PicName = details.PicName;
		}
	}
}
