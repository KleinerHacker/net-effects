using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.effects.Type
{
    /// <summary>
    /// Describe type of blending algorithm
    /// </summary>
    public enum BlendType
    {
        /// <summary>
        /// Overlay algorithm with alpha value
        /// </summary>
        Overlay = 0,
        /// <summary>
        /// Add algorithm
        /// </summary>
        Add = 1,
        /// <summary>
        /// Subtract algorithm
        /// </summary>
        Subtract = 2,
        /// <summary>
        /// Multiply algorithm
        /// </summary>
        Multiply = 3,
        /// <summary>
        /// Divide algorithm
        /// </summary>
        Divide = 4,
        /// <summary>
        /// Darken algorithm
        /// </summary>
        Darken = 5,
        /// <summary>
        /// Lighten algorithm
        /// </summary>
        Lighten = 6
    }
}
