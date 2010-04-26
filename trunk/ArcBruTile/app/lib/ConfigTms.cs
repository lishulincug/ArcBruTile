﻿// Copyright 2008 - Paul den Dulk (Geodan)
// 
// This file is part of SharpMap.
// SharpMap is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// SharpMap is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.

// You should have received a copy of the GNU Lesser General Public License
// along with SharpMap; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA 

using System;
using System.Collections.Generic;
using BruTile;
using BruTile.Web;
using BruTile.PreDefined;

namespace BruTileArcGIS
{
    public class ConfigTms : IConfig
    {
        public ITileSource CreateTileSource()
        {
            string url = "http://geoserver.nl/tiles/tilecache.aspx/1.0.0/world_GM/";
            var parameters = new Dictionary<string, string>();
            parameters.Add("seriveparam", "ortho10");
            TmsRequest request = new TmsRequest(new Uri(url), "png", parameters);
            return new TileSource(new WebTileProvider(request), new SphericalMercatorWorldSchema());
        }
    }
}
