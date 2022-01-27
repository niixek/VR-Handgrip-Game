import matplotlib.pyplot as plt
import sys
import os
import csv

def main():
    #Check if file path is given
    if len(sys.argv) == 3:
        #Get file
        file = sys.argv[1]
        savePath = sys.argv[2]

        #Check if csv file is imported:
        if file.endswith('.csv'):
            #Create graph
            time = []
            leftGrip = []
            rightGrip = []
            with open(file, 'r') as data:
                lineReader = csv.reader(data, delimiter = ',')

                skipFirst = True
                for row in lineReader:
                    if not skipFirst:
                        time.append(float(row[2]))
                        leftGrip.append(float(row[0]))
                        rightGrip.append(float(row[1]))
                    else:
                        skipFirst = False

            fig = plt.figure(figsize=(16,8))
            ax = fig.add_subplot(111)

            ax.plot(time, leftGrip, c='m', label='Left Grip')
            ax.plot(time, rightGrip, c='g', label='Right Grip')

            plt.legend(loc='upper left')
            plt.axis([0, max(time), min(min(leftGrip), min(rightGrip)), max(max(leftGrip), max(rightGrip)) + 10])
            plt.xlabel("Seconds")
            plt.ylabel("Newtons")
            #print(os.path.basename(file))

            #Save the graph image
            justFile = os.path.basename(file)
            newFile = savePath + os.path.splitext(justFile)[0] + '.png'
            #print(newFile)
            
            plt.savefig(newFile, dpi = 300)
            plt.close()
                
        else:
            print("Please provide a .csv file.")


    else:
        print("Please provide exactly one .csv file and Save Folder path.")
    
if __name__ == '__main__':
    main()