using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class JsonCV {
    public static JsonData Convert(string json) {
        json = json.Replace("},]", "}]");
        JsonData dataGet = JsonConvert.DeserializeObject<JsonData>(json);

        return dataGet;
    }
}

public class JsonData {
    public string Date { get; set; }
    public string Time { get; set; }
    public string LoginID { get; set; }
    public string SWVersion { get; set; }
    public string FWVersion { get; set; }
    public string SpecVersion { get; set; }
    public string TestTime { get; set; }
    public string LoadInOut { get; set; }
    public string Mode { get; set; }
    public string FinalResult { get; set; }
    public string SN { get; set; }
    public object Failure { get; set; }
    public List<ResultString_> ResultString { get; set; }

    public JsonData() {
        Date = string.Empty;
        Time = string.Empty;
        LoginID = string.Empty;
        SWVersion = string.Empty;
        FWVersion = string.Empty;
        SpecVersion = string.Empty;
        TestTime = string.Empty;
        LoadInOut = string.Empty;
        Mode = string.Empty;
        FinalResult = string.Empty;
        SN = string.Empty;
        Failure = string.Empty;
        ResultString = new List<ResultString_>();
    }
    public class ResultString_ {
        public string Step { get; set; }
        public string Description { get; set; }
        public string Tolerance { get; set; }
        public string Measured { get; set; }
        public string Result { get; set; }

        public ResultString_() {
            Step = string.Empty;
            Description = string.Empty;
            Tolerance = string.Empty;
            Measured = string.Empty;
            Result = string.Empty;
        }
    }
}
