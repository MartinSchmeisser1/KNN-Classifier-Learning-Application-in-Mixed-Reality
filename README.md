# KNN Classifier Learning Application in Mixed Reality


## User Documentation

Here we visualize a K-Nearest-Neighbor classifier, which is a very simple approach of Machine Learning. 
First, you can scan Tutorial Cards. 
The model will learn the gender, the weight, the height and the hairvolume from this training instances. 
After training, the model can be tested with Test Cards. 
There, only weight, height and hairvolume is given - the gender (the Target Attribute) is missing. 
The task of the model is now to classify the gender of the card, based on the given height, 
weight and hairvolume of the test card and the learned training examples.

If you want to reset the cards you already scanned, just scan the Reset Card.

The plot can be scaled or moved around in the room with using the grab gesture with two hands.

Note that on the 2D version, the attribute hairvolume is missing.  

### Precondition

The model can be trained and tested with training and testing instances. 

These instances are cards which QR codes which should be printed out before trying out the tool.

The cards can be found in the folder "cards".

### Further Information

This is a student project conducted in cooperation with the VIS chair of the University Bamberg. 

The tool is a learning application for whoever is interested in learning the basics of machine learning.

A K-Nearest-Neighbor Model (the simplest Machine Learning Model) can be trained and tested, while both processes are visualized.

### Demonstration Pictures

![Picture 1](/Readme_Pictures/Picture1.png)
![Picture 2](/Readme_Pictures/Picture2.png)
![Picture 3](/Readme_Pictures/Picture3.png)
![Picture 4](/Readme_Pictures/Picture4.png)
![Picture 5](/Readme_Pictures/Picture5.png)
 
            
### Known Problems

After scanning a QR code, a hologram of the QR code outlines is flying around in the room at the place where the QR code was scanned. 
This is a disturbing behaviour, but sadly there is no way to deal with this.
The only way to delete these holograms is to restart the HoloLens. 

[Further information](https://github.com/chgatla-microsoft/QRTracking/issues/41#issuecomment-921562061)

[Microsoft documentation](https://learn.microsoft.com/en-us/windows/mixed-reality/develop/advanced-concepts/qr-code-tracking-overview#managing-qr-code-data)

## Installation and Deployment
### Preconditions

1. Unity 2020
2. Visual Studio 2019

Both are free to use. For Visual Studio, just choose the community edition. 

### Open the project

1. Clone the repository. 
2. Open the folder of the project (either the 3D or 2D variant) with Unity.
3. Don't go into safe mode if errors will be shown.
4. Maybe you will need to go through a MRTK installation dialog.

### Build the project

Choose in the build settings in Unity "Universal Windows Platform" and choose the following parameters:

- Target Device: HoloLens
- Architecture: ARM64
- Build Type: D3D Project
- Visual Studio Version: Visual Studio 2019
- Build and Run on: Local Machine
- Build configuration: Release

Choose a folder where you want to store the build files.

After building, open the saved .snl file with Visual Studio 2019.

### Deploy the project

1. Make sure that the PC and the HoloLens are connected to the same network.
2. In Visual Studio, choose the deploy configurations "Master" + "ARM64".
3. Find out the IP of the HoloLens in the connection settings of the device or by saying "What is my IP?". 
4. Set the IP of the HoloLens under Configuration Properties --> Debugging --> Machine Name.
5. Click apply and then klick the “remote machine” button.

When starting the app you should have two free meters in front of you in the room, because the plot is instantiated two meters in front of the person.

The application will start after the deployment is done.
Futhermore, the application will be saved and can be started again from the menu anytime.
