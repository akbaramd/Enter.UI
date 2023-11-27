using System.Text;
using Enter.Ui.Core.Extensions;

namespace Enter.Ui.Core;

public class StyleBuilder
{
    #region Members

    const char Delimiter = ';';

    private readonly Action<StyleBuilder> buildStyles;

    private StringBuilder builder = new();

    private string styles;

    private bool clean = true;

    #endregion

    #region Constructors

    /// <summary>
    /// Default style builder constructor that accepts build action.
    /// </summary>
    /// <param name="buildStyles">Action responsible for building the styles.</param>
    public StyleBuilder( Action<StyleBuilder> buildStyles )
    {
        this.buildStyles = buildStyles;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Appends a copy of the specified string to this instance.
    /// </summary>
    /// <param name="value">The string to append.</param>
    public StyleBuilder AddStyle( string value )
    {
        if ( value is not null )
            builder.Append( value ).Append( Delimiter );
        return this;
    }

    /// <summary>
    /// Appends a copy of the specified string to this instance if <paramref name="condition"/> is true.
    /// </summary>
    /// <param name="value">The string to append.</param>
    /// <param name="condition">Condition that must be true.</param>
    public StyleBuilder AddStyle( string value, bool condition )
    {
        if ( value is not null && condition )
            builder.Append( value ).Append( Delimiter );

        return this;
    }

    /// <summary>
    /// Marks the builder as dirty to rebuild the values.
    /// </summary>
    public StyleBuilder CanUpdate()
    {
        clean = true;
        return this;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Get the styles.
    /// </summary>
    public string Build(string Tag = "")
    {
            if ( clean )
            {
                builder.Clear();

                buildStyles( this );

                styles = builder.ToString().TrimEnd( ' ', Delimiter )?.EmptyToNull();

                clean = false;
            }

            return styles;
    }

    #endregion
}