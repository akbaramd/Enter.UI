using System.Text;
using Enter.Ui.Core.Extensions;

namespace Enter.Ui.Core;

public class ClassBuilder
{
    #region Members

    private const char Delimiter = ' ';

    private readonly Action<ClassBuilder> buildClasses;

    private StringBuilder builder = new();

    private string classNames;

    private bool clean = true;

    #endregion

    #region Constructors

    /// <summary>
    /// Default class builder constructor that accepts build action.
    /// </summary>
    /// <param name="buildClasses">Action responsible for building the classes.</param>
    public ClassBuilder( Action<ClassBuilder> buildClasses )
    {
        this.buildClasses = buildClasses;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Appends a copy of the specified string to this instance.
    /// </summary>
    /// <param name="value">The string to append.</param>
    public ClassBuilder AddClass( string value )
    {
        if ( value == null )
            return this;

        builder.Append( value ).Append( Delimiter );
        return this;
    }

    /// <summary>
    /// Appends a copy of the specified string to this instance if <paramref name="condition"/> is true.
    /// </summary>
    /// <param name="value">The string to append.</param>
    /// <param name="condition">Condition that must be true.</param>
    public ClassBuilder AddClass( string value, bool condition )
    {
        if ( condition && value != null )
            builder.Append( value ).Append( Delimiter );

        return this;
    }

    /// <summary>
    /// Appends a copy of the specified list of strings to this instance.
    /// </summary>
    /// <param name="values">The list of strings to append.</param>
    public void AddClass( IEnumerable<string> values )
    {
        builder.Append( string.Join( Delimiter, values ) ).Append( Delimiter );
    }

    /// <summary>
    /// Marks the builder as dirty to rebuild the values.
    /// </summary>
    public ClassBuilder CanUpdate()
    {
        clean = true;
        return this;
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets the class-names.
    /// </summary>
    public string Build(string Tag = "")
    {
            if ( clean )
            {
                builder.Clear();

                buildClasses( this );

                classNames = builder.ToString().TrimEnd()?.EmptyToNull();

                clean = false;
            }

            return classNames;
    }

    #endregion
}