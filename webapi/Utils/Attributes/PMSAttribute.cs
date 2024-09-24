namespace CoffeeShop.Utils.Attributes;

public class PMSAttribute : Attribute
{
    public P_TYPE type { get; set; }
    public PMSAttribute(P_TYPE type)
    {
        this.type = type;
    }
}

public enum P_TYPE
{
    P_VIEW,
    P_CUSTOMIZE,
    P_VIEW_DATA,
    P_REFRESH,
    P_SEARCH,
    P_AUTHORIZE,
    P_APPROVE,
    P_REJECT,
    P_SUBMIT,
    P_REVERSE,
    P_ADD,
    P_EDIT,
    P_DELETE,
    P_SAVE,
    P_CLEAR,
    P_PRINT,
    P_IMPORT,
    P_EXPORT,
    P_COPY,
}
