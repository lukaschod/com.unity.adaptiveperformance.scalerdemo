using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AdaptivePerformance;

[DefaultExecutionOrder(102)]
public class ManualAdaptivePerformanceController : MonoBehaviour
{
    public Text Name;
    public Slider Level;
    public AdaptivePerformanceController Controller;

    public void SetLevel(float value)
    {
        var level = (int)(value * Controller.MaxLevel);
        Controller.OverrideLevel = level;
        Level.value = (float)level / Controller.MaxLevel;
    }

    private void Start()
    {
        if (!Controller)
            SetFirstAvailableController();
        Controller.OverrideLevel = 0;
        UpdateUI();
    }

    private bool SetFirstAvailableController()
    {
        var controllers = new List<AdaptivePerformanceController>();
        AdaptivePerformanceIndexer.Instance.GetUnappliedControllers(ref controllers);

        if (controllers.Count == 0)
            return false;

        Controller = controllers[0];

        return true;
    }

    private void UpdateUI()
    {
        Name.text = Controller.GetType().Name;
    }
}
