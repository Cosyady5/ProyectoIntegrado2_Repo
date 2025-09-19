using TMPro;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{

    private int currency;
    [SerializeField] TMP_Text currencyText;

    void Update()
    {
        CurrencyUpdater();
    }
    private int CurrencyUpdater()
    {
        currencyText.text = currency.ToString();
        return currency;
    }
    private void AddCurency(int amount)
    {
        amount += currency;
    }
    private void SpendCurrency(int amount)
    {
        amount -= currency;
    }
}
