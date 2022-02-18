using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Data;

public static class Geo
{
    public static Root GetGeoData(string value) => JsonConvert.DeserializeObject<Root>(value);

    public static string Serialise(object data) => JsonUtility.ToJson(data);// JsonConvert.SerializeObject(data);
}
