using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public class OutData
    {
        public int id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public Vector2[] points { get; set; }
        public List<List<object>> multiline { get; set; } 
        public OutData(Feature feature)
        {
            type = feature.geometry.type;
            id = feature.properties.ID_sect;
            name = feature.properties.name;
            switch (feature.geometry.type)
            {
                case "MultiLineString":
                    multiline = feature.geometry.coordinates;
                    break;
                case "LineString":
                    points = feature.geometry.coordinates.Select(list => new Vector2(list.ElementAt(0),list.ElementAt(1))).ToArray();
                    break;
            }
        }
    }


    public class Vector2
    {
        public Vector2()
        {
        }

        public Vector2(object x, object y)
        {
            this.x = (double)x;
            this.y = (double)y;
        }

        public double x { get; set; }
        public double y { get; set; }


    }


    public class Geometry
    {
        public string type { get; set; }
        public List<List<object>> coordinates { get; set; }
    }

    public class Properties
    {
        public string name { get; set; }
        public int ID_sect { get; set; }
        public int? Dotted { get; set; }
    }

    public class Feature
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }

    public class Root
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }
    }

}
