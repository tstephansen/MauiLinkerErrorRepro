using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;

namespace MauiLinkerErrorRepro;

public interface IWindowService
{
    bool MakeWindowTransparent(int index);
    bool EnableClickThroughForWindow(int index);
    bool DisableClickThroughForWindow(int index);
    bool RemoveBorderFromWindow(int index);
    bool AddBorderToWindow(int index);
    void MakeWindowsTransparent();
    void EnableClickThroughForAllWindows();
    void DisableClickThroughForAllWindows();
    void EnableClickThroughForNonKeyWindows();
    void DisableClickThroughForNonKeyWindows();
    void AddBorderToAllWindows();
    void RemoveBorderFromAllWindows();
    void AddBorderToNonKeyWindows();
    void RemoveBorderFromNonKeyWindows();
    int GetNumberOfWindows();
    bool SetWindowPosition(int index, double x, double y, double width, double height);
    void SetPositionForAllWindows(double x, double y, double width, double height);
    (double width, double height) GetScaledWindowDimensions(double scaleFactor = 1.0);
    (double x, double y) GetCenterScreenPosition(double scaleFactor = 1.0);
    void CenterWindowOnScreen(double scaleFactor = 1.0, bool ignoreScaleForPositioning = false, double? x = null,
        double? y = null);
    void MakeWindowsTakeUpWholeScreen();
    void SetWindowToFloat();
    void SetWindowToNormal();
}

public class WindowService : IWindowService
{
    private readonly ILogger<WindowService> _logger;
    public WindowService(ILogger<WindowService> logger)
    {
        _logger = logger;
    }

    public bool MakeWindowTransparent(int index)
    {
        try
        {
            return makeWindowTransparent(index);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error making the window transparent");
            return false;
        }
    }

    public bool EnableClickThroughForWindow(int index)
    {
        try
        {
            return enableClickThroughForWindow(index);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error enabling click through for window");
            return false;
        }
    }
    
    public bool DisableClickThroughForWindow(int index)
    {
        try
        {
            return disableClickThroughForWindow(index);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error disabling click through for window");
            return false;
        }
    }

    public bool RemoveBorderFromWindow(int index)
    {
        try
        {
            return removeBorderFromWindow(index);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error removing the border from the window");
            return false;
        }
    }

    public bool AddBorderToWindow(int index)
    {
        try
        {
            return addBorderToWindow(index);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding the border to the window");
            return false;
        }
    }
    
    public void MakeWindowsTransparent()
    {
        try
        {
            makeWindowsTransparent();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error making the windows transparent");
        }
    }
    public void EnableClickThroughForAllWindows()
    {
        try
        {
            enableClickThroughForAllWindows();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error enabling click through for all windows");
        }
    }
    
    public void DisableClickThroughForAllWindows()
    {
        try
        {
            disableClickThroughForAllWindows();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error disabling click through for all windows");
        }
    }
    
    public void EnableClickThroughForNonKeyWindows()
    {
        try
        {
            enableClickThroughForNonKeyWindows();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error enabling click through for non key windows");
        }
    }
    
    public void DisableClickThroughForNonKeyWindows()
    {
        try
        {
            disableClickThroughForNonKeyWindows();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error disabling click through for non key windows");
        }
    }
    
    public void AddBorderToAllWindows()
    {
        try
        {
            addBorderToAllWindows();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding the border to all windows");
        }
    }
    
    public void RemoveBorderFromAllWindows()
    {
        try
        {
            removeBorderFromAllWindows();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error removing the border from all windows");
        }
    }
    
    public void AddBorderToNonKeyWindows()
    {
        try
        {
            addBorderToNonKeyWindows();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding the border to non key windows");
        }
    }
    
    public void RemoveBorderFromNonKeyWindows()
    {
        try
        {
            removeBorderFromNonKeyWindows();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error removing the border from non key windows");
        }
    }

    public int GetNumberOfWindows()
    {
        try
        {
            return getNumberOfWindows();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting the number of open windows");
            return 0;
        }
    }

    public bool SetWindowPosition(int index, double x, double y, double width, double height)
    {
        try
        {
            return setWindowPosition(index, x, y, width, height);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error setting the window's position");
            return false;
        }
    }

    public void SetPositionForAllWindows(double x, double y, double width, double height)
    {
        try
        {
            setPositionForAllWindows(x, y, width, height);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error setting the position of all windows");
        }
    }

    public void MakeWindowsTakeUpWholeScreen()
    {
        var (width, height) = GetScaledWindowDimensions();
        SetPositionForAllWindows(0, 0, width, height);
    }
    
    public (double width, double height) GetScaledWindowDimensions(double scaleFactor = 1.0)
    {
        var displayInfo = DeviceDisplay.Current.MainDisplayInfo;
        var density = displayInfo.Density;
        var width = displayInfo.Width;
        var height = displayInfo.Height;
        var scaledWidth = width / density;
        var scaledHeight = height / density;
        return (scaledWidth * scaleFactor, scaledHeight * scaleFactor);
    }

    public (double x, double y) GetCenterScreenPosition(double scaleFactor = 1.0)
    {
        var (width, height) = GetScaledWindowDimensions(scaleFactor);
        var displayInfo = DeviceDisplay.Current.MainDisplayInfo;
        var density = displayInfo.Density;
        var screenWidth = displayInfo.Width / density;
        var screenHeight = displayInfo.Height / density;
        var x = (screenWidth - width) / 2;
        var y = (screenHeight - height) / 2;
        return (x, y);
    }

    // public void CenterWindowOnScreen(double scaleFactor = 1.0)
    // {
    //     var (width, height) = GetScaledWindowDimensions(scaleFactor);
    //     var (x, y) = GetCenterScreenPosition(scaleFactor);
    //     SetWindowPosition(0, x, y, width, height);
    // }
    
    public void CenterWindowOnScreen(double scaleFactor = 1.0, bool ignoreScaleForPositioning = false, double? x = null, double? y = null)
    {
        var (width, height) = GetScaledWindowDimensions(scaleFactor);
        if (x == null || y == null)
        {
            (x, y) = GetCenterScreenPosition(0.8);
            if (!ignoreScaleForPositioning)
                (x, y) = GetCenterScreenPosition();   
        }
        SetWindowPosition(0, x.GetValueOrDefault(), y.GetValueOrDefault(), width, height);
    }

    public void SetWindowToFloat()
    {
        try
        {
            setWindowToFloat();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error setting the window to float");
        }
    }
    
    public void SetWindowToNormal()
    {
        try
        {
            setWindowToNormal();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error setting the window to normal");
        }
    }
    
    [DllImport("__Internal")]
    private static extern bool makeWindowTransparent(int index);
    [DllImport("__Internal")]
    private static extern bool enableClickThroughForWindow(int index);
    [DllImport("__Internal")]
    private static extern bool disableClickThroughForWindow(int index);
    [DllImport("__Internal")]
    private static extern bool removeBorderFromWindow(int index);
    [DllImport("__Internal")]
    private static extern bool addBorderToWindow(int index);
    [DllImport("__Internal")]
    private static extern void makeWindowsTransparent();
    [DllImport("__Internal")]
    private static extern void enableClickThroughForAllWindows();
    [DllImport("__Internal")]
    private static extern void disableClickThroughForAllWindows();
    [DllImport("__Internal")]
    private static extern void enableClickThroughForNonKeyWindows();
    [DllImport("__Internal")]
    private static extern void disableClickThroughForNonKeyWindows();
    [DllImport("__Internal")]
    private static extern void removeBorderFromAllWindows();
    [DllImport("__Internal")]
    private static extern void addBorderToAllWindows();
    [DllImport("__Internal")]
    private static extern void addBorderToNonKeyWindows();
    [DllImport("__Internal")]
    private static extern void removeBorderFromNonKeyWindows();
    [DllImport("__Internal")]
    private static extern int getNumberOfWindows();
    [DllImport("__Internal")]
    private static extern bool setWindowPosition(int index, double x, double y, double width, double height);
    [DllImport("__Internal")]
    private static extern void setPositionForAllWindows(double x, double y, double width, double height);
    [DllImport("__Internal")]
    private static extern void setWindowToFloat();
    [DllImport("__Internal")]
    private static extern void setWindowToNormal();
}