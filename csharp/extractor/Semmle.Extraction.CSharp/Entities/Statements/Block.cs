using Microsoft.CodeAnalysis.CSharp.Syntax;
using Semmle.Extraction.Kinds;
using System.Linq;

namespace Semmle.Extraction.CSharp.Entities.Statements
{
    class Block : Statement<BlockSyntax>
    {
        Block(Context cx, BlockSyntax block, IStatementParentEntity parent, int child)
            : base(cx, block, StmtKind.BLOCK, parent, child) { }

        public static Block Create(Context cx, BlockSyntax node, IStatementParentEntity parent, int child)
        {
            var ret = new Block(cx, node, parent, child);
            ret.TryPopulate();
            return ret;
        }

        protected override void Populate()
        {
            var child = 0;
            foreach (var childStmt in Stmt.Statements.Select(c => Statement.Create(cx, c, this, child)))
            {
                child += childStmt.NumberOfStatements;
            }
        }
    }
}
