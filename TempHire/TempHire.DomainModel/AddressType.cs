//====================================================================================================================
// Copyright (c) 2013 IdeaBlade
//====================================================================================================================
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE 
// WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS 
// OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR 
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. 
//====================================================================================================================
// USE OF THIS SOFTWARE IS GOVERENED BY THE LICENSING TERMS WHICH CAN BE FOUND AT
// http://cocktail.ideablade.com/licensing
//====================================================================================================================

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace TempHire.DomainModel
{
    [DataContract]
    public class AddressType : EntityBase
    {
        public AddressType()
        {
        }

        /// <summary>Gets or sets the Id. </summary>

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [DataMember(IsRequired = true)]
        public Guid Id { get; set; }

        /// <summary>Gets or sets the Name. </summary>

        [Required]
        [DataMember(IsRequired = true)]
        public string Name { get; set; }

        /// <summary>Gets or sets the DisplayName. </summary>

        [Required]
        [DataMember(IsRequired = true)]
        public string DisplayName { get; set; }

        /// <summary>Gets or sets the Default. </summary>

        [Required]
        [DataMember(IsRequired = true)]
        public bool Default { get; set; }
    }
}