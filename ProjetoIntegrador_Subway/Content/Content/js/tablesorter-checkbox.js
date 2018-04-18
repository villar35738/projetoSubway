// add parser through the tablesorter addParser method
$.tablesorter.addParser({
    id: 'checkbox',
    is: function (s) {
        return false;
    },
    format: function (s, table, cell, cellIndex) {
        var c, $c = $(cell);
        // return 1 for true, 2 for false, so true sorts before false
        c = ($c.find('input[type=checkbox]')[0].checked) ? 1 : 2;
        $c.closest('tr').toggleClass('checked', c === 1);
        return c;
    },
    type: 'numeric'
});

/*!
	Copyright (C) 2011 T. Connell & Associates, Inc.

	Dual-licensed under the MIT and GPL licenses

	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
	MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
	FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
	WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

	Resizable scroller widget for the jQuery tablesorter plugin

	Version 2.0 - modified by Rob Garrison 4/12/2013; updated 6/18/2014 (v2.17.2)
	Requires jQuery v1.7+
	Requires the tablesorter plugin, v2.8+, available at http://mottie.github.com/tablesorter/docs/

	Usage:

		$(function() {

			$('table.tablesorter').tablesorter({
				widgets: ['zebra', 'scroller'],
				widgetOptions : {
					scroller_height       : 300,  // height of scroll window
					scroller_barWidth     : 18,   // scroll bar width
					scroller_jumpToHeader : true, // header snap to browser top when scrolling the tbody
					scroller_idPrefix     : 's_'  // cloned thead id prefix (random number added to end)
				}
			});

		});

	Website: www.tconnell.com
*/
/*jshint browser:true, jquery:true, unused:false */
(function ($) {
                // column containing all of the checkboxes (zero-based index)
                var ck, $hdrCheckbox,
                    c = table.config,
                    wo = c.widgetOptions,
                    $t = $(table),
                    columnWithCheckboxes = 0,
                    // resort the table after the checkbox status has changed
                    resort = false;

                $hdrCheckbox = $t
                    // ==== make this work with the scroller widget ====
                    .add($t.closest('.tablesorter-scroller'))

                    // make checkbox in header set all others
                    .find('thead th input[type=checkbox]')
                    .bind('change', function () {
                        ck = this.checked;
                        $t
                            .children('tbody')
                            .find('tr td:nth-child(' + (columnWithCheckboxes + 1) + ') input')
                            .each(function () {
                                this.checked = ck;
                                $(this).trigger('change');
                            });
                        // make sure stickyHeader checkbox gets updated
                        $hdrCheckbox.prop('checked', ck);
                    })
                    .bind('mouseup', function () {
                        return false;
                    });

                $t.find('tbody tr').each(function () {
                    $(this)
                        .find('td:eq(' + columnWithCheckboxes + ')')
                        .find('input[type=checkbox]')
                        .bind('change', function () {
                            $t.trigger('updateCell', [$(this).closest('td')[0], resort]);
                        });
                });
            
        });