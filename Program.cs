//*****************************************************************************
//** 1509. Minimum Difference Between Largest and Smallest Value in Three    **
//**       Moves leetcode                                                    **
//*****************************************************************************


// Compare function for qsort
int compare(const void* a, const void* b) {
    return (*(int*)a - *(int*)b);
}

int minDifference(int* nums, int numsSize) {
    if(numsSize <= 4) return 0; // You can change 3 numbers to match, resulting in an output of 0

    // Sort the array
    qsort(nums, numsSize, sizeof(int), compare);
    
 //   for(int i = 0; i < numsSize; i++) printf("nums[%d] = %d\n",i,nums[i]); // Make sure it's sorted

    int left = 0;
    int right = numsSize-1;
    int diff[7] = {0};
    diff[0] = nums[left+1] - nums[left];
    diff[1] = nums[left+2] - nums[left+1];
    diff[2] = nums[left+3] - nums[left+2];
    diff[3] = nums[right] - nums[right-1];
    diff[4] = nums[right-1] - nums[right-2];
    diff[5] = nums[right-2] - nums[right-3];
 //   for(int i = 0; i < 6; i++) printf("diff[%d] = %d\n",i,diff[i]);
    int l = 0;
    int r = 3;
    int largest1 = 0;
    int largest2 = 0;
    int largest3 = 0;
    int largest4 = 0;
    largest1 = diff[0] + diff[1] + diff[2];
    largest2 = diff[0] + diff[1] + diff[3];
    largest3 = diff[0] + diff[3] + diff[4];
    largest4 = diff[3] + diff[4] + diff[5];
    if(largest1 > largest2 && largest1 > largest3 && largest1 > largest4) 
    {   
//        printf("Removing left 3\n");
        l = 3;
        r = 0;
    }
    else if(largest2 > largest1 && largest2 > largest3 && largest2 > largest4) 
    {   
//        printf("Removing left 2, right 1\n");
        l = 2;
        r = 1;
    }
    else if(largest3 > largest1 && largest3 > largest2 && largest3 > largest4) 
    {   
//        printf("Removing left 1, right 2\n");
        l = 1;
        r = 2;
    }
    else if(largest4 > largest1 && largest4 > largest2 && largest4 > largest3) 
    {   
//        printf("Removing right 3\n");
        l = 0;
        r = 3;
    }
    else
    {
//        printf("They are equal?!?!\n");
        if((nums[numsSize - 4]-nums[0]) > (nums[numsSize-1] - nums[3]))
        {
            l = 3;
            r = 0;
        }
        else
        {
            l = 0;
            r = 3;
        }
    }

/*
    int subleft = 3;
    while(subleft > 0)
    {
        if(diff[l] > diff[r]) 
        {
            l++;
            subleft--;
        }
        if(diff[l] < diff[r]) 
        {
            r++;
            subleft--;
        }
        if(diff[l]==diff[r])
        {
            if(subleft > 1)
            {
                if(diff[l+1] > diff[r+1])
                {
                    l++;
                    l++;
                    subleft--;
                    subleft--;
                }
                else if(diff[l+1] < diff[r+1])
                {
                    r++;
                    r++;
                    subleft--;
                    subleft--;
                }
                else if(diff[l+1] == diff[r+1])
                {
                    if(subleft > 2)
                    {
                        if(diff[l+2] > diff[r+2])
                        {
                            l++;
                            l++;
                            l++;
                            subleft--;
                            subleft--;
                            subleft--;
                        }
                        else if(diff[l+2] < diff[r+2])
                        {
                            r++;
                            r++;
                            r++;
                            subleft--;
                            subleft--;
                            subleft--;
                        }
                    }
                    else
                    {
                        l++;
                        l++;
                        subleft--;
                        subleft--;
                    }
                }
            }
            else
            {
                l++;
                subleft--;
            }
        
        }   

    }
    if(l > 3) l = 3;
*/
    left = l;
    right = numsSize - r - 1;
// Trying something new
    int leftside = 0;
    int rightside = 0;
/*
    if(nums[left+1]-nums[left] > nums[right]-nums[right-1]) left++;
    else right--;
    if(nums[left+1]-nums[left] > nums[right]-nums[right-1]) left++;
    else right--;
    if(nums[left+1]-nums[left] > nums[right]-nums[right-1]) left++;
    else right--;
*/
//    printf("Num[%d] = %d minus num[%d] = %d\n",left,nums[left],right,nums[right]);
    int retNum = nums[right]-nums[left];
    return retNum;

}