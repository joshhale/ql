/**
 * @name SSA
 * @description Insert description here...
 * @kind problem
 * @problem.severity warning
 */

import python


from ControlFlowNode defn, SsaVariable v, AugAssign a, BinaryExpr b
where v.getDefinition() = defn and a.getOperation() = b and b.contains((Expr)defn.getNode())
select defn.toString(), defn.getNode().getLocation().getStartLine()