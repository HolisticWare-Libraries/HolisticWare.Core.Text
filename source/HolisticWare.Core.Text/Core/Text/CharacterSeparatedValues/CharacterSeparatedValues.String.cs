using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Text
{
    public partial class CharacterSeparatedValues
    {
        public IEnumerable<IEnumerable<string>> ParseUsingString
                                                        (
                                                            char column_delimiter,
                                                            string row_delimiter
                                                        )
        {
            return this.ParseUsingString(column_delimiter, row_delimiter);
        }


        public Type ContainedType
        {
            get;
            set;
        }

        public Func
                <
                    string,
                    char,
                    IEnumerable<string[]>
                >
                    ParseLineImplementation 
        {
            get;
            set;
        }


        public delegate IEnumerable<RowType> TransformationMethod<RowType>(IEnumerable<string[]> untyped_data);

        protected TransformationMethod<string[]> TransformationDefault;

        public IEnumerable<string[]> Transformation(IEnumerable<string[]> untyped_data)
        {
            return untyped_data;
        }
    }
}