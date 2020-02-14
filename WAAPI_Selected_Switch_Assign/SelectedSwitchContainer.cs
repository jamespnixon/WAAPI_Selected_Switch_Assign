using System;
using System.Collections.Generic;
using System.Text;

namespace WAAPI_Selected_Switch_Assign
{
    class SelectedSwitchContainer
    {

        public string name { get; set; }

        public string id { get; set; }

        public string switchGroupOrStateGroup { get; set; }

        public List<SwitchContainerChild> children = new List<SwitchContainerChild>();
    }

    public class SwitchContainerChild
    {
        public string name { get; set; }
        public string id { get; set; }

        public string stateOrSwitch { get; set; }


    }

    public class WwiseSwitch
    {

    public string name { get; set; }
    public string id { get; set; }
    
    }

}
