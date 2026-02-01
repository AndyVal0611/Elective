using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elective
{
    internal class PayrollClass
    {
        // === All global variables from PayrollFunctionForm ===
        public double basicnetincome, basic_numhrs, basic_rate;
        public double hono_netincome, hono_numhrs, hono_rate;
        public double other_netincome, other_numhrs, other_rate;
        public double netincome, grossincome;

        public double sss_contrib, pagibig_contrib = 100, philhealth_contrib, tax_contrib;
        public double sss_loan, pagibig_loan, salary_loan, faculty_sav_loan, other_deduction, salary_savings;
        public double total_deduction;

        // === Contribution tables ===
        public readonly double[] philRanges = {
            10000, 11000, 12000, 13000, 14000, 15000, 16000, 17000, 18000, 19000, 20000,
            21000, 22000, 23000, 24000, 25000, 26000, 27000, 28000, 29000, 30000,
            31000, 32000, 33000, 34000, 35000, 36000, 37000, 38000, 39000
        };

        public readonly double[] philAmounts = {
            137.50, 151.25, 165.00, 178.75, 192.50, 206.25, 220.00, 233.75, 247.50, 261.25,
            275.25, 288.75, 302.50, 316.25, 330.00, 343.75, 357.50, 371.25, 385.00, 398.75,
            412.50, 426.25, 440.00, 453.75, 467.50, 481.25, 495.00, 508.75, 522.50, 536.25
        };

        public readonly double[] sssRanges = {
            1000, 1249.99, 1749.99, 2249.99, 2749.99, 3249.99, 3749.99, 4249.99,
            4749.99, 5249.99, 5749.99, 6249.99, 6749.99, 7249.99, 7749.99, 8249.99,
            8749.99, 9249.99, 9749.99, 10249.99, 10749.99, 11249.99, 11749.99, 12249.99,
            12749.99, 13249.99, 13749.99, 14249.99, 14749.99, 15249.99, 15749.99, 16249.99
        };

        public readonly double[] sssAmounts = {
            0.00, 36.30, 54.50, 72.70, 90.80, 109.00, 127.20, 145.30,
            163.50, 181.70, 199.80, 218.00, 236.20, 254.30, 272.50, 290.70,
            308.80, 327.00, 345.20, 363.30, 381.50, 399.70, 417.80, 436.00,
            454.20, 472.30, 490.50, 508.70, 526.80, 545.00, 563.20, 581.30
        };
    }
}
