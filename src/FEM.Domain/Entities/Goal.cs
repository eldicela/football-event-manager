
using FEM.Domain.Enums;

namespace FEM.Domain.Entities;

public class Goal
{
    public int Id { get; set; }
    public int MatchId {  get; set; }
    public int TeamId { get; set; }
    public int PlayerId { get; set; }
    public int Minute {  get; set; }
    public GoalType Type { get; set; }
}
