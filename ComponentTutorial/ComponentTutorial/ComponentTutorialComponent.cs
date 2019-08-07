using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//these are necessary to allow for you to do most anything you need within your component
using LiveSplit.Model;
using LiveSplit.Model.Input;
using LiveSplit.ComponentTutorial;
using ComponentTutorial;
using LiveSplit.UI.Components;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

//this namespace is necessary in order to make a component correctly, as this class uses a livesplit component interface in order to be recognizable
namespace LiveSplit.UI.Components
{
    //This class must implement IComponent in order to display and run correctly

    //There are other component interfaces to implement (you can look at them by doing LiveSplit.UI.Components.___ and looking for interfaces)
    //the main 2 interfaces are IComponent, which uses a display attatched to livesplit, and the LogicComponent which does not require a display at all
    public class ComponentTutorialComponent : UI.Components.IComponent
    {
        //The only things that is required for a new component is to make a settings control and have an object of it in this class
        //to access the code for the settings user control, go under it's directory and clock on Settings()
        public Settings settings;

        //livesplitstate allows you to track most anything happening with livesplit, like when a run starts, what the current split is, when teh run splits, etc.
        // always try to refrain from creating a new liveplsitstate variable and instead just get it passed in from the component factory so that nothing weird happens
        // and there is only one state that you get your information from
        public LiveSplitState state;

        //create a constructor for this class that includes an argument for LiveSplits State
        public ComponentTutorialComponent(LiveSplitState state)
        {
            //get the state from the factory
            this.state = state;

            //create a new settings object for this component as each one will need its own settings
            settings = new Settings(state);

            //set the width and height(horizontal and vertical refer to which mode livesplit is in)
            HorizontalWidth = 100;
            VerticalHeight = 100;
        }

        //make sure this matches the factory
        //this should really only be read-only
        public string ComponentName => "Component Tutorial";

        //depending on your component you can make these readonly or changeable, just as long as they are readable
        public float HorizontalWidth { get; set; }

        //minimums are where the window can only be so small
        public float MinimumHeight { get; set; }

        public float VerticalHeight { get; set; }

        public float MinimumWidth { get; set; }

        //padding determines how much space is put between the componet and the rest of livesplit
        public float PaddingTop { get; set; }

        public float PaddingBottom { get; set; }

        public float PaddingLeft { get; set; }

        public float PaddingRight { get; set; }

        //this is for when your componet is right clicked, I haven't really had to use this but you can certainly mess around and add contexstmenu items
        public IDictionary<string, Action> ContextMenuControls { get; set; }
        
        //this method draws the component when Livesplit is in horizontal mode
        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
        {
            //here is where you draw what you want for your component, I would recommend looking at microsoft c# tutorials on graphics and painting/drawing
            //Pen pen = new Pen(Color.Red, 5);
            //g.DrawLine(pen, 0, 0, HorizontalWidth, VerticalHeight);
        }

        //this method draws the component when Livesplit is in vertical mode
        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
        {
            //for simplicity I am just going to keep the drawing the same for each layout mode
            DrawHorizontal(g, state, width, clipRegion);
        }

        //this function gets the settings from the settings user control and puts them in the layout file for livesplit
        public XmlNode GetSettings(XmlDocument document)
        {
            return settings.GetSettings(document);
        }
        
        //this gets teh user control to be displayed in livesplit
        public Control GetSettingsControl(LayoutMode mode)
        {
            return settings;
        }

        //this method sets the settings for the component that were saved to the layout file
        public void SetSettings(XmlNode settings)
        {
            this.settings.SetSettings(settings);
        }

        //this update funciton updates the component, not much I need to do here but feel free to experiment with this
        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {

        }

        
        //when implementing the interface, have visual studio create this for you, by selecting implement interface with dispose pattern(the last option)
        //this function gets rid of objects that aren't being used, like when the component is closed
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ComponentTutorialComponent() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
