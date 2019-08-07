//copy this page exactly!


using LiveSplit.ComponentTutorial;
using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: ComponentFactory(typeof(ComponentTutorialFactory))]

namespace LiveSplit.ComponentTutorial
{
    public class ComponentTutorialFactory : IComponentFactory
    {

        //this is the category underwhich youur component will be available
        public ComponentCategory Category
        {
            //you can change the component category to any of the other options
            get { return ComponentCategory.Other; }
        }

        //this is the name that livesplit will display this component as
        public string ComponentName
        {
            get { return "Compoent Tutorial"; }
        }

        //this funciton creates a new instance of your component from the component class
        public IComponent Create(Model.LiveSplitState state)
        {
            return new ComponentTutorialComponent(state);
        }

        //this is a description that is displayed when the component is hovered over
        public string Description
        {
            get { return "This is a tutorial on how to create a component"; }
        }

        // all of this stuff has to do with updating,
        //I am not really sure how it all works, but I think you can link it to a github page or something in order to have livesplit update your component
        public string UpdateName
        {
            get { return ComponentName; }
        }

        public string UpdateURL
        {
            get { return ""; }
        }

        public Version Version
        {
            get { return Version.Parse("0.0"); }
        }

        public string XMLURL
        {
            get { return UpdateURL + ""; }
        }
    }
}
