using System;
using System.Collections.Generic;
using System.Linq;

public class Judge : IJudge
{
    private HashSet<int> users;
    private HashSet<int> contests;
    private Dictionary<int, Submission> judge;

    public Judge()
    {
        this.users = new HashSet<int>();
        this.contests = new HashSet<int>();
        this.judge = new Dictionary<int, Submission>();
    }

    public void AddContest(int contestId)
    {
        this.contests.Add(contestId);
    }

    public void AddSubmission(Submission submission)
    {
        if (!this.users.Contains(submission.UserId)
            || !this.contests.Contains(submission.ContestId))
        {
            throw new InvalidOperationException();
        }

        if (!this.judge.ContainsKey(submission.Id))
        {
            this.judge[submission.Id] = submission;
        }
    }

    public void AddUser(int userId)
    {
        this.users.Add(userId);
    }

    public void DeleteSubmission(int submissionId)
    {
        if (!this.judge.ContainsKey(submissionId))
        {
            throw new InvalidOperationException();
        }

        this.judge.Remove(submissionId);
    }

    public IEnumerable<Submission> GetSubmissions()
    {
        return this.judge
            .Values
            .OrderBy(x=>x);
    }

    public IEnumerable<int> GetUsers()
    {
        return this.users
            .OrderBy(x => x);
    }

    public IEnumerable<int> GetContests()
    {
        return this.contests
            .OrderBy(x=>x);
    }

    public IEnumerable<Submission> SubmissionsWithPointsInRangeBySubmissionType(int minPoints, int maxPoints, SubmissionType submissionType)
    {
        return this.judge
            .Values
            .Where(x => x.Type == submissionType
            && x.Points >= minPoints
            && x.Points <= maxPoints);
    }

    public IEnumerable<int> ContestsByUserIdOrderedByPointsDescThenBySubmissionId(int userId)
    {
        if (!this.users.Contains(userId)
            ||!this.judge.Values.Any(x=>x.UserId==userId))
        {
            throw new InvalidOperationException();
        }

        var result = new HashSet<int>(this.judge
            .Values
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.Points)
            .ThenBy(x => x.Id)
            .Select(x => x.ContestId));

        return result;
    }

    public IEnumerable<Submission> SubmissionsInContestIdByUserIdWithPoints(int points, int contestId, int userId)
    {
        if (!this.users.Contains(userId)
            || !this.contests.Contains(contestId)
            || !this.judge.Values.Any(x => x.Points == points))
        {
            throw new InvalidOperationException();
        }

        return this.judge
            .Values
            .Where(x => x.Points == points
            && x.ContestId == contestId
            && x.UserId == userId);
    }

    public IEnumerable<int> ContestsBySubmissionType(SubmissionType submissionType)
    {
        HashSet<int> result = new HashSet<int>(this.judge
            .Values
            .Where(x => x.Type == submissionType)
            .Select(x => x.ContestId));
        return result;
    }
}
