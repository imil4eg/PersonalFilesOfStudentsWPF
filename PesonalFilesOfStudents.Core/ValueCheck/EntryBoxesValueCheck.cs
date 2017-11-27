using System;
using System.Collections.Generic;
using System.Windows;

namespace PesonalFilesOfStudents.Core
{
    /// <summary>
    /// The class that check typed values in entry boxes (only for studentinformation)
    /// </summary>
    public static class EntryBoxesValueCheck
    {
        #region Private list

        /// <summary>
        /// Holds all entry boxes to check values 
        /// </summary>
        private static List<TextEntryViewModel> entrysTocheck = new List<TextEntryViewModel>();

        #endregion

        /// <summary>
        /// Check values from entry boxes at specific order
        /// </summary>
        /// <param name="_textEntrys">Entry boxes to check </param>
        /// <returns></returns>
        public static bool Check(List<TextEntryViewModel> _textEntrys)
        {
            entrysTocheck.Clear();

            // Add all can't be null values into list
            entrysTocheck.AddRange(new[]
            {
                _textEntrys[1], _textEntrys[3], _textEntrys[6], _textEntrys[7], _textEntrys[8],
                _textEntrys[10], _textEntrys[11], _textEntrys[13], _textEntrys[14], _textEntrys[15],
                _textEntrys[16], _textEntrys[25], _textEntrys[26],_textEntrys[27],_textEntrys[28]
            });

            //Check if this entry box has any value (studentmiddlename,studentregistration,studentgender)
            CheckIsValuesNull(_textEntrys[2]);
            
            // Check student BirthDate
            CheckIsValuesNull(_textEntrys[4]);  /*     This boxes can't be setted    */
                                                /*                                   */
            // check studentRegistration        /*                                   */
            CheckIsValuesNull(_textEntrys[5]);  /*        in one method              */
                                                /*                                   */
            // Check studentGender              /*                                   */
            CheckIsValuesNull(_textEntrys[9]);  /*  because of || logic checking in method */

            // Check parent values
            CheckIsValuesNull(_textEntrys[18], _textEntrys[17], _textEntrys[20]);

            // Check second parent values
            CheckIsValuesNull(_textEntrys[22], _textEntrys[21], _textEntrys[24]);

            // Checksecond education
            CheckIsValuesNull(_textEntrys[29], _textEntrys[30]);

            // Check third education
            CheckIsValuesNull(_textEntrys[31], _textEntrys[32]);

            foreach (var item in entrysTocheck)
            {
                // Checks if some textbox is empty and show the message and end this method
                if (!string.IsNullOrWhiteSpace(item.OriginalText)) continue;
                MessageBox.Show(string.Format("The box {0} can't be empty", item.Label), "Error");
                return false;


            }

            // Clear list
            entrysTocheck.Clear();

            // Paste all values that must be string into list
            // Check students string values where can't be numbers
            entrysTocheck.AddRange(new[]
            {
            _textEntrys[1],_textEntrys[3],_textEntrys[2],
        });

            //Check if this entry box has any value
            // first two is parentfirstname and parentlastname
            // second one is secondparentfirstname and secondparentlastname
            CheckIsValuesNull(_textEntrys[18], _textEntrys[17]);

            CheckIsValuesNull(_textEntrys[22], _textEntrys[21]);

            CheckIsValuesNull(_textEntrys[9]);

            // Each element of list...
            foreach (var item in entrysTocheck)
            {
                // Check if this item is null
                if (!string.IsNullOrWhiteSpace(item.OriginalText))
                {
                    // Check every element on having a letter in it
                    foreach (var c in item.OriginalText)
                    {
                        // if it have a letter , Show messagebox with error and end method
                        if (char.IsNumber(c))
                        {
                            MessageBox.Show(string.Format("The enter box {0} must contain only letters", item.Label),
                                "Error");
                            return false;
                        }
                    }
                }
            }

            // Clear list
            entrysTocheck.Clear();

            // Check values studentcourse,studentfaculty,studentINN,studentsnils,PassportNumber,
            // PassportSeries, InsurencePolicyNumber 
            // on having letters in values
            entrysTocheck.AddRange(new[]
            {
                _textEntrys[6], _textEntrys[7], _textEntrys[10], _textEntrys[11],
                _textEntrys[13], _textEntrys[14], _textEntrys[25]
            });

            
            // Check if first parents firstname and lastname isn't null or white space
            // if not adding first parents phone to list to check it's values
            if(!string.IsNullOrWhiteSpace(_textEntrys[18].OriginalText) || !string.IsNullOrWhiteSpace(_textEntrys[17].OriginalText))
                entrysTocheck.Add(_textEntrys[20]);

            // Check if second parents firstname and lastname isn't null or white space
            // if not adding second parents phone to list to check it's values
            if (!string.IsNullOrWhiteSpace(_textEntrys[22].OriginalText) || !string.IsNullOrWhiteSpace(_textEntrys[21].OriginalText))
                entrysTocheck.Add(_textEntrys[24]);

            int check = 0;

            // Each element of list...
            foreach (var item in entrysTocheck)
            {
                // trying parse value to int , if true show message box with error and end this method
                if (!int.TryParse(item.OriginalText, out check))
                {
                    MessageBox.Show(string.Format("The enter box {0} must contain only nums", item.Label), "Error");
                    return false;
                }
            }

            // Clear list
            entrysTocheck.Clear();

            // Entered can't be null vallues with date to check (PassportIssuedDate,EducationEndDate1)
            entrysTocheck.AddRange(new [] {_textEntrys[16],_textEntrys[28]});

            //Check if this entry box has any value(StudentBirthDate)
            CheckIsValuesNull(_textEntrys[4]);

            // (EducationEndDate2)
            CheckIsValuesNull(_textEntrys[30]);
            // (EducationEndDate3)
            CheckIsValuesNull(_textEntrys[32]);

            DateTime checkTime;

            // Each element of list...
            foreach (var item in entrysTocheck)
            {
                // trying parse value to DateTime , if true show message box with error and end this method
                if (!DateTime.TryParse(item.OriginalText, out checkTime))
                {
                    MessageBox.Show(string.Format("The date in {0} must be like dd-mm-yyyy", item.Label), "Error");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// This method check if someof entry boxes has value
        /// </summary>
        /// <param name="firstTextEntry"></param>
        /// <param name="secondTextEntry"></param>
        /// <param name="thirdTextEntry"></param>
        private static void CheckIsValuesNull(params TextEntryViewModel[] textEntrys)
        {
            if (textEntrys.Length == 1 && !string.IsNullOrWhiteSpace(textEntrys[0].OriginalText))
            {
                entrysTocheck.Add(textEntrys[0]);
            }
            if (textEntrys.Length == 2 &&
                (!string.IsNullOrWhiteSpace(textEntrys[0].OriginalText) || !string.IsNullOrWhiteSpace(textEntrys[1].OriginalText)))
            {
                entrysTocheck.AddRange(new[] { textEntrys[0], textEntrys[1] });
            }

            if (textEntrys.Length == 3 &&
                (!string.IsNullOrWhiteSpace(textEntrys[0].OriginalText) ||
                 !string.IsNullOrWhiteSpace(textEntrys[1].OriginalText) ||
                 !string.IsNullOrWhiteSpace(textEntrys[2].OriginalText)))
            {
                entrysTocheck.AddRange(new[] { textEntrys[0], textEntrys[1], textEntrys[2] });
            }
        }
    }
}
