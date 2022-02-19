/*
Given an array of meeting time intervals where intervals[i] = [starti, endi], determine if a person could attend all meetings.

Example 1:

Input: intervals = [[0,30],[5,10],[15,20]]
Output: false
Example 2:

Input: intervals = [[7,10],[2,4]]
Output: true
*/

/*
253. Meeting Rooms II
Medium

5135

101

Add to List

Share
Given an array of meeting time intervals intervals where intervals[i] = [starti, endi], return the minimum number of conference rooms required. 

Example 1:

Input: intervals = [[0,30],[5,10],[15,20]]
Output: 2
Example 2:

Input: intervals = [[7,10],[2,4]]
Output: 1
 

Constraints:

1 <= intervals.length <= 104
0 <= starti < endi <= 106
*/
public class MeetingRoomsCal
{
    public bool CanPersonAttend(int[][] intervals)
    {
        if (intervals == null) { return false; }
        Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0]));
        int[] curr = intervals[0];
        for (int i = 1; i < intervals.Length; i++)
        {
            if (curr[1] > intervals[i][0])
            {
                return false;
            }
            else
            {
                curr = intervals[i];
            }
        }

        return true;
    }

    public int GetRequiredMeetingRooms(int[][] intervals)
    {
        if (intervals == null || intervals[0].Length == 0) { return 0; }
        Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0]));
        int[] curr = intervals[0];
        int rooms = 0;
        for (int i = 1; i < intervals.Length; i++)
        {
            
        }

        return rooms;
    }

    [Fact]
    public void Test()
    {
        var expected1 = false;
        var intervals1 = new List<int[]>{
            new int[]{0, 30 },
            new int[]{5, 10 },
            new int[]{15, 20 },
        };

        var actual1 = CanPersonAttend(intervals1.ToArray());
        Xunit.Assert.Equal(actual1, expected1);

        var expected2 = true;
        var intervals2 = new List<int[]>{
            new int[]{7, 10 },
            new int[]{2, 4 }
        };

        var actual2 = CanPersonAttend(intervals2.ToArray());
        Xunit.Assert.Equal(actual2, expected2);
    }

    [Fact]
    public void Test1()
    {
        var expected1 = 1;
        var intervals1 = new List<int[]>{
            new int[]{0, 30 },
            new int[]{5, 10 },
            new int[]{15, 20 },
        };

        var actual1 = GetRequiredMeetingRooms(intervals1.ToArray());
        Xunit.Assert.Equal(actual1, expected1);

        var expected2 = 2;
        var intervals2 = new List<int[]>{
            new int[]{7, 10 },
            new int[]{2, 4 }
        };

        var actual2 = GetRequiredMeetingRooms(intervals2.ToArray());
        Xunit.Assert.Equal(actual2, expected2);
    }
}