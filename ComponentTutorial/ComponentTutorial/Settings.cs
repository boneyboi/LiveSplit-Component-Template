using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//these are all necessary for what the settings class should do
using ComponentTutorial;
using System.Xml;
using LiveSplit.Model;
using System.IO;
using System.Collections;
using System.Drawing.Imaging;
using System.Runtime.Serialization;

//The settings must also be under the LiveSplit.UI.Components as it uses things from the namespace to set and get settings
namespace LiveSplit.UI.Components
{
    public partial class Settings : UserControl
    {
        public LiveSplitState state;

        //so for this page I will create one setting and that should be a good template for how to create settings and save or load them
        //a setting can be anything you want
        public Boolean clicked { get; set; }

        public Settings(LiveSplitState state)
        {
            //this initializes the form and it's controls for you
            //NOTE: make sure this is the first thing that happens, otherwise adding the event handlers will cause an error
            InitializeComponent();


            this.state = state;

            //initialize the setting variables
            clicked = false;


            //add databindings to settings
            //this means that the controls will have data binded to teh setting variables, it doesn't inherently do anything,
            //but it is required for liveplsit to recognize your component
            checkBox1.DataBindings.Add(new Binding("Checked", this, "clicked"));
            //^"Control name".-----------------------^"property name", "dataset", "data memeber/as in the setting"
            ////////////////the "property name" MUST MUST MUST be an actual property within the control////////////////


            //add eventhandlers to the controls
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;

            //this is another event for when the settings load
            this.Load += settings_load;
        }

        

        //gets the current variables states, puts them in an xml doc and sends it to livesplit to save in the layout file (this is called from the component class first)
        public XmlNode GetSettings(XmlDocument document)
        {
            //this adds the node of settings.cs to the document passed in
            //make a parent with the document created element of "Settings" and add nodes to that through AppendChild
            var parent = document.CreateElement("Settings");

            //title!
            //----------------------------------------| this arg must be this.ToString()
            //document.CreateElement(this.ToString()).InnerText = "Component Tutorial";
            var Element = document.CreateElement(this.ToString());
            Element.InnerText = "Component Tutorial";
            parent.AppendChild(Element);
            //elements!
            //You have to create an element (like Element), then change its value through innertext, and apppend it as a child to the parent
            Element = document.CreateElement("Clicked");
            Element.InnerText = clicked.ToString();
            parent.AppendChild(Element);
            //returns that node that was just created
            return parent;
        }


        //gets the settings from livesplit and sets the variables here to the values given (the settings are obtained from the set settings funciton in the component)
        public void SetSettings(XmlNode settings)
        {
            //the settings node is the same as one created in GetSettings
            //The main point of this funciton is to check for changes and then assign those changes to the variables the elements are connected to
            if (settings["Clicked"].InnerText != null)
            {
                //set the value from the settings to the corresponding variable
                clicked = bool.Parse(settings["Clicked"].InnerText);
            }
        }

        private void settings_load(object sender, EventArgs e)
        {
            //make sure that everything is synced with what the settings currently are, also make sure to add this sort of event to the component, in case you have settings
            //that interact with the component
            clicked = checkBox1.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            clicked = checkBox1.Checked;
        }
    }
}
