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

        public IEnumerable<string[]> Parse()
        {
            return this.ParseTemporaryImplementation();
        }

        public IEnumerable<string[]> ParseTemporaryImplementation()
                        // // Error CS0702: Constraint cannot be special class 'ValueType'         
                        // where T : ValueType
        {
            string[] lines = Text.Split
                                        (
                                            new string[] { Environment.NewLine, @"\n" },
                                            StringSplitOptions.RemoveEmptyEntries
                                        );

            for (int i = 0; i < lines.Length; i++)
            {
                string[] columns = lines[i].Split
                                        (
                                            new char[] { ',' },
                                            StringSplitOptions.RemoveEmptyEntries
                                        );

                yield return columns;
            }
        }

        public delegate IEnumerable<T> TransformationMethod<T>(IEnumerable<string[]> untyped_data);

        protected TransformationMethod<string[]> TransformationDefault;

        public IEnumerable<string[]> Transformation(IEnumerable<string[]> untyped_data)
        {
            return untyped_data;
        }
    }
}