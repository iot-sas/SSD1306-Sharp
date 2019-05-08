using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSD1306;

namespace SSD1306.Fonts
{

    /* FontCharacterDescripter contains font information for a  single character */
    public class Tahmona8 : IFont
    {

        public uint PageCount { get; } = 2;
        public uint CharSpacing { get; } = 3;
    
        Dictionary<char, uint[]> FontList = new Dictionary<char, uint[]>();
        public byte[] Data { get; } = new byte[]
    
{
    // @0 '!' (1 pixels wide)
    //  
    // #
    // #
    // #
    // #
    // #
    // #
    //  
    // #
    //  
    //  
    0x7E, 
    0x01, 

    // @2 '"' (3 pixels wide)
    // # #
    // # #
    // # #
    //    
    //    
    //    
    //    
    //    
    //    
    //    
    //    
    0x07, 0x00, 0x07, 
    0x00, 0x00, 0x00, 

    // @8 '#' (7 pixels wide)
    //        
    //    # # 
    //    # # 
    //  ######
    //   # #  
    //   # #  
    // ###### 
    //  # #   
    //  # #   
    //        
    //        
    0x40, 0xC8, 0x78, 0xCE, 0x78, 0x4E, 0x08, 
    0x00, 0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 

    // @22 '$' (5 pixels wide)
    //   #  
    //   #  
    //  ####
    // # #  
    // # #  
    //  ### 
    //   # #
    //   # #
    // #### 
    //   #  
    //   #  
    0x18, 0x24, 0xFF, 0x24, 0xC4, 
    0x01, 0x01, 0x07, 0x01, 0x00, 

    // @32 '%' (10 pixels wide)
    //           
    //  ##   #   
    // #  #  #   
    // #  # #    
    //  ##  #    
    //     #  ## 
    //     # #  #
    //    #  #  #
    //    #   ## 
    //           
    //           
    0x0C, 0x12, 0x12, 0x8C, 0x60, 0x18, 0xC6, 0x20, 0x20, 0xC0, 
    0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x01, 0x00, 

    // @52 '&' (7 pixels wide)
    //        
    //  ##    
    // #  #   
    // #  #   
    //  ##  # 
    // #  # # 
    // #   #  
    // #   ## 
    //  ###  #
    //        
    //        
    0xEC, 0x12, 0x12, 0x2C, 0xC0, 0xB0, 0x00, 
    0x00, 0x01, 0x01, 0x01, 0x00, 0x00, 0x01, 

    // @66 ''' (1 pixels wide)
    // #
    // #
    // #
    //  
    //  
    //  
    //  
    //  
    //  
    //  
    //  
    0x07, 
    0x00, 

    // @68 '(' (3 pixels wide)
    //   #
    //  # 
    //  # 
    // #  
    // #  
    // #  
    // #  
    // #  
    //  # 
    //  # 
    //   #
    0xF8, 0x06, 0x01, 
    0x00, 0x03, 0x04, 

    // @74 ')' (3 pixels wide)
    // #  
    //  # 
    //  # 
    //   #
    //   #
    //   #
    //   #
    //   #
    //  # 
    //  # 
    // #  
    0x01, 0x06, 0xF8, 
    0x04, 0x03, 0x00, 

    // @80 '*' (5 pixels wide)
    //   #  
    // # # #
    //  ### 
    // # # #
    //   #  
    //      
    //      
    //      
    //      
    //      
    //      
    0x0A, 0x04, 0x1F, 0x04, 0x0A, 
    0x00, 0x00, 0x00, 0x00, 0x00, 

    // @90 '+' (7 pixels wide)
    //        
    //        
    //    #   
    //    #   
    //    #   
    // #######
    //    #   
    //    #   
    //    #   
    //        
    //        
    0x20, 0x20, 0x20, 0xFC, 0x20, 0x20, 0x20, 
    0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 

    // @104 ',' (2 pixels wide)
    //   
    //   
    //   
    //   
    //   
    //   
    //   
    //  #
    //  #
    //  #
    // # 
    0x00, 0x80, 
    0x04, 0x03, 

    // @108 '-' (3 pixels wide)
    //    
    //    
    //    
    //    
    //    
    // ###
    //    
    //    
    //    
    //    
    //    
    0x20, 0x20, 0x20, 
    0x00, 0x00, 0x00, 

    // @114 '.' (1 pixels wide)
    //  
    //  
    //  
    //  
    //  
    //  
    //  
    // #
    // #
    //  
    //  
    0x80, 
    0x01, 

    // @116 '/' (3 pixels wide)
    //   #
    //   #
    //   #
    //  # 
    //  # 
    //  # 
    //  # 
    //  # 
    // #  
    // #  
    // #  
    0x00, 0xF8, 0x07, 
    0x07, 0x00, 0x00, 

    // @122 '0' (5 pixels wide)
    //      
    //  ### 
    // #   #
    // #   #
    // #   #
    // #   #
    // #   #
    // #   #
    //  ### 
    //      
    //      
    0xFC, 0x02, 0x02, 0x02, 0xFC, 
    0x00, 0x01, 0x01, 0x01, 0x00, 

    // @132 '1' (3 pixels wide)
    //    
    //  # 
    // ## 
    //  # 
    //  # 
    //  # 
    //  # 
    //  # 
    // ###
    //    
    //    
    0x04, 0xFE, 0x00, 
    0x01, 0x01, 0x01, 

    // @138 '2' (5 pixels wide)
    //      
    //  ### 
    // #   #
    //     #
    //    # 
    //   #  
    //  #   
    // #    
    // #####
    //      
    //      
    0x84, 0x42, 0x22, 0x12, 0x0C, 
    0x01, 0x01, 0x01, 0x01, 0x01, 

    // @148 '3' (5 pixels wide)
    //      
    //  ### 
    // #   #
    //     #
    //   ## 
    //     #
    //     #
    // #   #
    //  ### 
    //      
    //      
    0x84, 0x02, 0x12, 0x12, 0xEC, 
    0x00, 0x01, 0x01, 0x01, 0x00, 

    // @158 '4' (5 pixels wide)
    //      
    //    # 
    //   ## 
    //  # # 
    // #  # 
    // #####
    //    # 
    //    # 
    //    # 
    //      
    //      
    0x30, 0x28, 0x24, 0xFE, 0x20, 
    0x00, 0x00, 0x00, 0x01, 0x00, 

    // @168 '5' (5 pixels wide)
    //      
    // #####
    // #    
    // #    
    // #### 
    //     #
    //     #
    // #   #
    //  ### 
    //      
    //      
    0x9E, 0x12, 0x12, 0x12, 0xE2, 
    0x00, 0x01, 0x01, 0x01, 0x00, 

    // @178 '6' (5 pixels wide)
    //      
    //   ## 
    //  #   
    // #    
    // #### 
    // #   #
    // #   #
    // #   #
    //  ### 
    //      
    //      
    0xF8, 0x14, 0x12, 0x12, 0xE0, 
    0x00, 0x01, 0x01, 0x01, 0x00, 

    // @188 '7' (5 pixels wide)
    //      
    // #####
    //     #
    //    # 
    //    # 
    //   #  
    //   #  
    //  #   
    //  #   
    //      
    //      
    0x02, 0x82, 0x62, 0x1A, 0x06, 
    0x00, 0x01, 0x00, 0x00, 0x00, 

    // @198 '8' (5 pixels wide)
    //      
    //  ### 
    // #   #
    // #   #
    //  ### 
    // #   #
    // #   #
    // #   #
    //  ### 
    //      
    //      
    0xEC, 0x12, 0x12, 0x12, 0xEC, 
    0x00, 0x01, 0x01, 0x01, 0x00, 

    // @208 '9' (5 pixels wide)
    //      
    //  ### 
    // #   #
    // #   #
    // #   #
    //  ####
    //     #
    //    # 
    //  ##  
    //      
    //      
    0x1C, 0x22, 0x22, 0xA2, 0x7C, 
    0x00, 0x01, 0x01, 0x00, 0x00, 

    // @218 ':' (1 pixels wide)
    //  
    //  
    //  
    // #
    // #
    //  
    //  
    // #
    // #
    //  
    //  
    0x98, 
    0x01, 

    // @220 ';' (2 pixels wide)
    //   
    //   
    //   
    //  #
    //  #
    //   
    //   
    //  #
    //  #
    //  #
    // # 
    0x00, 0x98, 
    0x04, 0x03, 

    // @224 '<' (6 pixels wide)
    //       
    //       
    //      #
    //    ## 
    //  ##   
    // #     
    //  ##   
    //    ## 
    //      #
    //       
    //       
    0x20, 0x50, 0x50, 0x88, 0x88, 0x04, 
    0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 

    // @236 '=' (7 pixels wide)
    //        
    //        
    //        
    //        
    // #######
    //        
    // #######
    //        
    //        
    //        
    //        
    0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 0x50, 
    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 

    // @250 '>' (6 pixels wide)
    //       
    //       
    // #     
    //  ##   
    //    ## 
    //      #
    //    ## 
    //  ##   
    // #     
    //       
    //       
    0x04, 0x88, 0x88, 0x50, 0x50, 0x20, 
    0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 

    // @262 '?' (4 pixels wide)
    //     
    // ### 
    //    #
    //    #
    //   # 
    //  #  
    //  #  
    //     
    //  #  
    //     
    //     
    0x02, 0x62, 0x12, 0x0C, 
    0x00, 0x01, 0x00, 0x00, 

    // @270 '@' (9 pixels wide)
    //          
    //   #####  
    //  #     # 
    // #  ###  #
    // # #  #  #
    // # #  #  #
    // # #  #  #
    // #  ##### 
    //  #       
    //   ####   
    //          
    0xF8, 0x04, 0x72, 0x8A, 0x8A, 0xFA, 0x82, 0x84, 0x78, 
    0x00, 0x01, 0x02, 0x02, 0x02, 0x02, 0x00, 0x00, 0x00, 

    // @288 'A' (6 pixels wide)
    //       
    //   ##  
    //   ##  
    //  #  # 
    //  #  # 
    //  #  # 
    // ######
    // #    #
    // #    #
    //       
    //       
    0xC0, 0x78, 0x46, 0x46, 0x78, 0xC0, 
    0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 

    // @300 'B' (5 pixels wide)
    //      
    // #### 
    // #   #
    // #   #
    // #### 
    // #   #
    // #   #
    // #   #
    // #### 
    //      
    //      
    0xFE, 0x12, 0x12, 0x12, 0xEC, 
    0x01, 0x01, 0x01, 0x01, 0x00, 

    // @310 'C' (6 pixels wide)
    //       
    //   ####
    //  #    
    // #     
    // #     
    // #     
    // #     
    //  #    
    //   ####
    //       
    //       
    0x78, 0x84, 0x02, 0x02, 0x02, 0x02, 
    0x00, 0x00, 0x01, 0x01, 0x01, 0x01, 

    // @322 'D' (6 pixels wide)
    //       
    // ####  
    // #   # 
    // #    #
    // #    #
    // #    #
    // #    #
    // #   # 
    // ####  
    //       
    //       
    0xFE, 0x02, 0x02, 0x02, 0x84, 0x78, 
    0x01, 0x01, 0x01, 0x01, 0x00, 0x00, 

    // @334 'E' (5 pixels wide)
    //      
    // #####
    // #    
    // #    
    // #### 
    // #    
    // #    
    // #    
    // #####
    //      
    //      
    0xFE, 0x12, 0x12, 0x12, 0x02, 
    0x01, 0x01, 0x01, 0x01, 0x01, 

    // @344 'F' (5 pixels wide)
    //      
    // #####
    // #    
    // #    
    // #####
    // #    
    // #    
    // #    
    // #    
    //      
    //      
    0xFE, 0x12, 0x12, 0x12, 0x12, 
    0x01, 0x00, 0x00, 0x00, 0x00, 

    // @354 'G' (6 pixels wide)
    //       
    //   ####
    //  #    
    // #     
    // #     
    // #  ###
    // #    #
    //  #   #
    //   ####
    //       
    //       
    0x78, 0x84, 0x02, 0x22, 0x22, 0xE2, 
    0x00, 0x00, 0x01, 0x01, 0x01, 0x01, 

    // @366 'H' (6 pixels wide)
    //       
    // #    #
    // #    #
    // #    #
    // ######
    // #    #
    // #    #
    // #    #
    // #    #
    //       
    //       
    0xFE, 0x10, 0x10, 0x10, 0x10, 0xFE, 
    0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 

    // @378 'I' (3 pixels wide)
    //    
    // ###
    //  # 
    //  # 
    //  # 
    //  # 
    //  # 
    //  # 
    // ###
    //    
    //    
    0x02, 0xFE, 0x02, 
    0x01, 0x01, 0x01, 

    // @384 'J' (4 pixels wide)
    //     
    //  ###
    //    #
    //    #
    //    #
    //    #
    //    #
    //    #
    // ### 
    //     
    //     
    0x00, 0x02, 0x02, 0xFE, 
    0x01, 0x01, 0x01, 0x00, 

    // @392 'K' (5 pixels wide)
    //      
    // #   #
    // #  # 
    // # #  
    // ##   
    // ##   
    // # #  
    // #  # 
    // #   #
    //      
    //      
    0xFE, 0x30, 0x48, 0x84, 0x02, 
    0x01, 0x00, 0x00, 0x00, 0x01, 

    // @402 'L' (4 pixels wide)
    //     
    // #   
    // #   
    // #   
    // #   
    // #   
    // #   
    // #   
    // ####
    //     
    //     
    0xFE, 0x00, 0x00, 0x00, 
    0x01, 0x01, 0x01, 0x01, 

    // @410 'M' (7 pixels wide)
    //        
    // ##   ##
    // ##   ##
    // # # # #
    // # # # #
    // #  #  #
    // #  #  #
    // #     #
    // #     #
    //        
    //        
    0xFE, 0x06, 0x18, 0x60, 0x18, 0x06, 0xFE, 
    0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 

    // @424 'N' (6 pixels wide)
    //       
    // ##   #
    // ##   #
    // # #  #
    // # #  #
    // #  # #
    // #  # #
    // #   ##
    // #   ##
    //       
    //       
    0xFE, 0x06, 0x18, 0x60, 0x80, 0xFE, 
    0x01, 0x00, 0x00, 0x00, 0x01, 0x01, 

    // @436 'O' (7 pixels wide)
    //        
    //   ###  
    //  #   # 
    // #     #
    // #     #
    // #     #
    // #     #
    //  #   # 
    //   ###  
    //        
    //        
    0x78, 0x84, 0x02, 0x02, 0x02, 0x84, 0x78, 
    0x00, 0x00, 0x01, 0x01, 0x01, 0x00, 0x00, 

    // @450 'P' (5 pixels wide)
    //      
    // #### 
    // #   #
    // #   #
    // #   #
    // #### 
    // #    
    // #    
    // #    
    //      
    //      
    0xFE, 0x22, 0x22, 0x22, 0x1C, 
    0x01, 0x00, 0x00, 0x00, 0x00, 

    // @460 'Q' (7 pixels wide)
    //        
    //   ###  
    //  #   # 
    // #     #
    // #     #
    // #     #
    // #     #
    //  #   # 
    //   ###  
    //     #  
    //      ##
    0x78, 0x84, 0x02, 0x02, 0x02, 0x84, 0x78, 
    0x00, 0x00, 0x01, 0x01, 0x03, 0x04, 0x04, 

    // @474 'R' (6 pixels wide)
    //       
    // ####  
    // #   # 
    // #   # 
    // #   # 
    // ####  
    // #  #  
    // #   # 
    // #    #
    //       
    //       
    0xFE, 0x22, 0x22, 0x62, 0x9C, 0x00, 
    0x01, 0x00, 0x00, 0x00, 0x00, 0x01, 

    // @486 'S' (5 pixels wide)
    //      
    //  ####
    // #    
    // #    
    //  ### 
    //     #
    //     #
    //     #
    // #### 
    //      
    //      
    0x0C, 0x12, 0x12, 0x12, 0xE2, 
    0x01, 0x01, 0x01, 0x01, 0x00, 

    // @496 'T' (5 pixels wide)
    //      
    // #####
    //   #  
    //   #  
    //   #  
    //   #  
    //   #  
    //   #  
    //   #  
    //      
    //      
    0x02, 0x02, 0xFE, 0x02, 0x02, 
    0x00, 0x00, 0x01, 0x00, 0x00, 

    // @506 'U' (6 pixels wide)
    //       
    // #    #
    // #    #
    // #    #
    // #    #
    // #    #
    // #    #
    // #    #
    //  #### 
    //       
    //       
    0xFE, 0x00, 0x00, 0x00, 0x00, 0xFE, 
    0x00, 0x01, 0x01, 0x01, 0x01, 0x00, 

    // @518 'V' (5 pixels wide)
    //      
    // #   #
    // #   #
    // #   #
    //  # # 
    //  # # 
    //  # # 
    //   #  
    //   #  
    //      
    //      
    0x0E, 0x70, 0x80, 0x70, 0x0E, 
    0x00, 0x00, 0x01, 0x00, 0x00, 

    // @528 'W' (9 pixels wide)
    //          
    // #   #   #
    // #   #   #
    // #   #   #
    //  # # # # 
    //  # # # # 
    //  # # # # 
    //   #   #  
    //   #   #  
    //          
    //          
    0x0E, 0x70, 0x80, 0x70, 0x0E, 0x70, 0x80, 0x70, 0x0E, 
    0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 

    // @546 'X' (5 pixels wide)
    //      
    // #   #
    // #   #
    //  # # 
    //   #  
    //   #  
    //  # # 
    // #   #
    // #   #
    //      
    //      
    0x86, 0x48, 0x30, 0x48, 0x86, 
    0x01, 0x00, 0x00, 0x00, 0x01, 

    // @556 'Y' (5 pixels wide)
    //      
    // #   #
    // #   #
    //  # # 
    //  # # 
    //   #  
    //   #  
    //   #  
    //   #  
    //      
    //      
    0x06, 0x18, 0xE0, 0x18, 0x06, 
    0x00, 0x00, 0x01, 0x00, 0x00, 

    // @566 'Z' (5 pixels wide)
    //      
    // #####
    //     #
    //    # 
    //   #  
    //   #  
    //  #   
    // #    
    // #####
    //      
    //      
    0x82, 0x42, 0x32, 0x0A, 0x06, 
    0x01, 0x01, 0x01, 0x01, 0x01, 

    // @576 '[' (3 pixels wide)
    // ###
    // #  
    // #  
    // #  
    // #  
    // #  
    // #  
    // #  
    // #  
    // #  
    // ###
    0xFF, 0x01, 0x01, 
    0x07, 0x04, 0x04, 

    // @582 '\' (3 pixels wide)
    // #  
    // #  
    // #  
    //  # 
    //  # 
    //  # 
    //  # 
    //  # 
    //   #
    //   #
    //   #
    0x07, 0xF8, 0x00, 
    0x00, 0x00, 0x07, 

    // @588 ']' (3 pixels wide)
    // ###
    //   #
    //   #
    //   #
    //   #
    //   #
    //   #
    //   #
    //   #
    //   #
    // ###
    0x01, 0x01, 0xFF, 
    0x04, 0x04, 0x07, 

    // @594 '^' (7 pixels wide)
    //        
    //    #   
    //   # #  
    //  #   # 
    // #     #
    //        
    //        
    //        
    //        
    //        
    //        
    0x10, 0x08, 0x04, 0x02, 0x04, 0x08, 0x10, 
    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 

    // @608 '_' (6 pixels wide)
    //       
    //       
    //       
    //       
    //       
    //       
    //       
    //       
    //       
    //       
    // ######
    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
    0x04, 0x04, 0x04, 0x04, 0x04, 0x04, 

    // @620 '`' (2 pixels wide)
    // # 
    //  #
    //   
    //   
    //   
    //   
    //   
    //   
    //   
    //   
    //   
    0x01, 0x02, 
    0x00, 0x00, 

    // @624 'a' (5 pixels wide)
    //      
    //      
    //      
    //  ### 
    //     #
    //  ####
    // #   #
    // #   #
    //  ####
    //      
    //      
    0xC0, 0x28, 0x28, 0x28, 0xF0, 
    0x00, 0x01, 0x01, 0x01, 0x01, 

    // @634 'b' (5 pixels wide)
    // #    
    // #    
    // #    
    // #### 
    // #   #
    // #   #
    // #   #
    // #   #
    // #### 
    //      
    //      
    0xFF, 0x08, 0x08, 0x08, 0xF0, 
    0x01, 0x01, 0x01, 0x01, 0x00, 

    // @644 'c' (4 pixels wide)
    //     
    //     
    //     
    //  ###
    // #   
    // #   
    // #   
    // #   
    //  ###
    //     
    //     
    0xF0, 0x08, 0x08, 0x08, 
    0x00, 0x01, 0x01, 0x01, 

    // @652 'd' (5 pixels wide)
    //     #
    //     #
    //     #
    //  ####
    // #   #
    // #   #
    // #   #
    // #   #
    //  ####
    //      
    //      
    0xF0, 0x08, 0x08, 0x08, 0xFF, 
    0x00, 0x01, 0x01, 0x01, 0x01, 

    // @662 'e' (5 pixels wide)
    //      
    //      
    //      
    //  ### 
    // #   #
    // #####
    // #    
    // #   #
    //  ### 
    //      
    //      
    0xF0, 0x28, 0x28, 0x28, 0xB0, 
    0x00, 0x01, 0x01, 0x01, 0x00, 

    // @672 'f' (3 pixels wide)
    //  ##
    // #  
    // #  
    // ###
    // #  
    // #  
    // #  
    // #  
    // #  
    //    
    //    
    0xFE, 0x09, 0x09, 
    0x01, 0x00, 0x00, 

    // @678 'g' (5 pixels wide)
    //      
    //      
    //      
    //  ####
    // #   #
    // #   #
    // #   #
    // #   #
    //  ####
    //     #
    //  ### 
    0xF0, 0x08, 0x08, 0x08, 0xF8, 
    0x00, 0x05, 0x05, 0x05, 0x03, 

    // @688 'h' (5 pixels wide)
    // #    
    // #    
    // #    
    // #### 
    // #   #
    // #   #
    // #   #
    // #   #
    // #   #
    //      
    //      
    0xFF, 0x08, 0x08, 0x08, 0xF0, 
    0x01, 0x00, 0x00, 0x00, 0x01, 

    // @698 'i' (1 pixels wide)
    //  
    // #
    //  
    // #
    // #
    // #
    // #
    // #
    // #
    //  
    //  
    0xFA, 
    0x01, 

    // @700 'j' (2 pixels wide)
    //   
    //  #
    //   
    // ##
    //  #
    //  #
    //  #
    //  #
    //  #
    //  #
    // # 
    0x08, 0xFA, 
    0x04, 0x03, 

    // @704 'k' (5 pixels wide)
    // #    
    // #    
    // #    
    // #  # 
    // # #  
    // ##   
    // # #  
    // #  # 
    // #   #
    //      
    //      
    0xFF, 0x20, 0x50, 0x88, 0x00, 
    0x01, 0x00, 0x00, 0x00, 0x01, 

    // @714 'l' (1 pixels wide)
    // #
    // #
    // #
    // #
    // #
    // #
    // #
    // #
    // #
    //  
    //  
    0xFF, 
    0x01, 

    // @716 'm' (7 pixels wide)
    //        
    //        
    //        
    // ### ## 
    // #  #  #
    // #  #  #
    // #  #  #
    // #  #  #
    // #  #  #
    //        
    //        
    0xF8, 0x08, 0x08, 0xF0, 0x08, 0x08, 0xF0, 
    0x01, 0x00, 0x00, 0x01, 0x00, 0x00, 0x01, 

    // @730 'n' (5 pixels wide)
    //      
    //      
    //      
    // #### 
    // #   #
    // #   #
    // #   #
    // #   #
    // #   #
    //      
    //      
    0xF8, 0x08, 0x08, 0x08, 0xF0, 
    0x01, 0x00, 0x00, 0x00, 0x01, 

    // @740 'o' (5 pixels wide)
    //      
    //      
    //      
    //  ### 
    // #   #
    // #   #
    // #   #
    // #   #
    //  ### 
    //      
    //      
    0xF0, 0x08, 0x08, 0x08, 0xF0, 
    0x00, 0x01, 0x01, 0x01, 0x00, 

    // @750 'p' (5 pixels wide)
    //      
    //      
    //      
    // #### 
    // #   #
    // #   #
    // #   #
    // #   #
    // #### 
    // #    
    // #    
    0xF8, 0x08, 0x08, 0x08, 0xF0, 
    0x07, 0x01, 0x01, 0x01, 0x00, 

    // @760 'q' (5 pixels wide)
    //      
    //      
    //      
    //  ####
    // #   #
    // #   #
    // #   #
    // #   #
    //  ####
    //     #
    //     #
    0xF0, 0x08, 0x08, 0x08, 0xF8, 
    0x00, 0x01, 0x01, 0x01, 0x07, 

    // @770 'r' (3 pixels wide)
    //    
    //    
    //    
    // # #
    // ## 
    // #  
    // #  
    // #  
    // #  
    //    
    //    
    0xF8, 0x10, 0x08, 
    0x01, 0x00, 0x00, 

    // @776 's' (4 pixels wide)
    //     
    //     
    //     
    //  ###
    // #   
    // ##  
    //   ##
    //    #
    // ### 
    //     
    //     
    0x30, 0x28, 0x48, 0xC8, 
    0x01, 0x01, 0x01, 0x00, 

    // @784 't' (3 pixels wide)
    //    
    // #  
    // #  
    // ###
    // #  
    // #  
    // #  
    // #  
    //  ##
    //    
    //    
    0xFE, 0x08, 0x08, 
    0x00, 0x01, 0x01, 

    // @790 'u' (5 pixels wide)
    //      
    //      
    //      
    // #   #
    // #   #
    // #   #
    // #   #
    // #   #
    //  ####
    //      
    //      
    0xF8, 0x00, 0x00, 0x00, 0xF8, 
    0x00, 0x01, 0x01, 0x01, 0x01, 

    // @800 'v' (5 pixels wide)
    //      
    //      
    //      
    // #   #
    // #   #
    //  # # 
    //  # # 
    //   #  
    //   #  
    //      
    //      
    0x18, 0x60, 0x80, 0x60, 0x18, 
    0x00, 0x00, 0x01, 0x00, 0x00, 

    // @810 'w' (7 pixels wide)
    //        
    //        
    //        
    // #  #  #
    // #  #  #
    // # # # #
    // # # # #
    //  #   # 
    //  #   # 
    //        
    //        
    0x78, 0x80, 0x60, 0x18, 0x60, 0x80, 0x78, 
    0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 

    // @824 'x' (5 pixels wide)
    //      
    //      
    //      
    // #   #
    //  # # 
    //   #  
    //   #  
    //  # # 
    // #   #
    //      
    //      
    0x08, 0x90, 0x60, 0x90, 0x08, 
    0x01, 0x00, 0x00, 0x00, 0x01, 

    // @834 'y' (5 pixels wide)
    //      
    //      
    //      
    // #   #
    // #   #
    //  # # 
    //  # # 
    //   #  
    //   #  
    //  #   
    //  #   
    0x18, 0x60, 0x80, 0x60, 0x18, 
    0x00, 0x06, 0x01, 0x00, 0x00, 

    // @844 'z' (4 pixels wide)
    //     
    //     
    //     
    // ####
    //    #
    //   # 
    //  #  
    // #   
    // ####
    //     
    //     
    0x88, 0x48, 0x28, 0x18, 
    0x01, 0x01, 0x01, 0x01, 

    // @852 '{' (4 pixels wide)
    //    #
    //   # 
    //   # 
    //   # 
    //   # 
    // ##  
    //   # 
    //   # 
    //   # 
    //   # 
    //    #
    0x20, 0x20, 0xDE, 0x01, 
    0x00, 0x00, 0x03, 0x04, 

    // @860 '|' (1 pixels wide)
    // #
    // #
    // #
    // #
    // #
    // #
    // #
    // #
    // #
    // #
    // #
    0xFF, 
    0x07, 

    // @862 '}' (4 pixels wide)
    // #   
    //  #  
    //  #  
    //  #  
    //  #  
    //   ##
    //  #  
    //  #  
    //  #  
    //  #  
    // #   
    0x01, 0xDE, 0x20, 0x20, 
    0x04, 0x03, 0x00, 0x00, 

    // @870 '~' (7 pixels wide)
    //        
    //        
    //        
    //        
    //  ##   #
    // #  #  #
    // #   ## 
    //        
    //        
    //        
    //        
    0x60, 0x10, 0x10, 0x20, 0x40, 0x40, 0x30, 
    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
};
        
        public FontInfo GetChar(char chr)
        {
            FontInfo fontInfo = null;
            uint[] data;
            if (FontList.TryGetValue(chr, out data))
            {
                fontInfo = new FontInfo(chr,data);
            }
        
            return fontInfo;
        }
        
        public Tahmona8()
        {
            
          FontList.Add('!',new uint[]{1,0,1});
          FontList.Add('"',new uint[]{3,2,7});
          FontList.Add('#',new uint[]{7,8,21});
          FontList.Add('$',new uint[]{5,22,31});
          FontList.Add('%',new uint[]{10,32,51});
          FontList.Add('&',new uint[]{7,52,65});
          FontList.Add('\'',new uint[]{1,66,67});
          FontList.Add('(',new uint[]{3,68,73});
          FontList.Add(')',new uint[]{3,74,79});
          FontList.Add('*',new uint[]{5,80,89});
          FontList.Add('+',new uint[]{7,90,103});
          FontList.Add(',',new uint[]{2,104,107});
          FontList.Add('-',new uint[]{3,108,113});
          FontList.Add('.',new uint[]{1,114,115});
          FontList.Add('/',new uint[]{3,116,121});
          FontList.Add('0',new uint[]{5,122,131});
          FontList.Add('1',new uint[]{3,132,137});
          FontList.Add('2',new uint[]{5,138,147});
          FontList.Add('3',new uint[]{5,148,157});
          FontList.Add('4',new uint[]{5,158,167});
          FontList.Add('5',new uint[]{5,168,177});
          FontList.Add('6',new uint[]{5,178,187});
          FontList.Add('7',new uint[]{5,188,197});
          FontList.Add('8',new uint[]{5,198,207});
          FontList.Add('9',new uint[]{5,208,217});
          FontList.Add(':',new uint[]{1,218,219});
          FontList.Add(';',new uint[]{2,220,223});
          FontList.Add('<',new uint[]{6,224,235});
          FontList.Add('=',new uint[]{7,236,249});
          FontList.Add('>',new uint[]{6,250,261});
          FontList.Add('?',new uint[]{4,262,269});
          FontList.Add('@',new uint[]{9,270,287});
          FontList.Add('A',new uint[]{6,288,299});
          FontList.Add('B',new uint[]{5,300,309});
          FontList.Add('C',new uint[]{6,310,321});
          FontList.Add('D',new uint[]{6,322,333});
          FontList.Add('E',new uint[]{5,334,343});
          FontList.Add('F',new uint[]{5,344,353});
          FontList.Add('G',new uint[]{6,354,365});
          FontList.Add('H',new uint[]{6,366,377});
          FontList.Add('I',new uint[]{3,378,383});
          FontList.Add('J',new uint[]{4,384,391});
          FontList.Add('K',new uint[]{5,392,401});
          FontList.Add('L',new uint[]{4,402,409});
          FontList.Add('M',new uint[]{7,410,423});
          FontList.Add('N',new uint[]{6,424,435});
          FontList.Add('O',new uint[]{7,436,449});
          FontList.Add('P',new uint[]{5,450,459});
          FontList.Add('Q',new uint[]{7,460,473});
          FontList.Add('R',new uint[]{6,474,485});
          FontList.Add('S',new uint[]{5,486,495});
          FontList.Add('T',new uint[]{5,496,505});
          FontList.Add('U',new uint[]{6,506,517});
          FontList.Add('V',new uint[]{5,518,527});
          FontList.Add('W',new uint[]{9,528,545});
          FontList.Add('X',new uint[]{5,546,555});
          FontList.Add('Y',new uint[]{5,556,565});
          FontList.Add('Z',new uint[]{5,566,575});
          FontList.Add('[',new uint[]{3,576,581});
          FontList.Add('\\',new uint[]{3,582,587});
          FontList.Add(']',new uint[]{3,588,593});
          FontList.Add('^',new uint[]{7,594,607});
          FontList.Add('_',new uint[]{6,608,619});
          FontList.Add('`',new uint[]{2,620,623});
          FontList.Add('a',new uint[]{5,624,633});
          FontList.Add('b',new uint[]{5,634,643});
          FontList.Add('c',new uint[]{4,644,651});
          FontList.Add('d',new uint[]{5,652,661});
          FontList.Add('e',new uint[]{5,662,671});
          FontList.Add('f',new uint[]{3,672,677});
          FontList.Add('g',new uint[]{5,678,687});
          FontList.Add('h',new uint[]{5,688,697});
          FontList.Add('i',new uint[]{1,698,699});
          FontList.Add('j',new uint[]{2,700,703});
          FontList.Add('k',new uint[]{5,704,713});
          FontList.Add('l',new uint[]{1,714,715});
          FontList.Add('m',new uint[]{7,716,729});
          FontList.Add('n',new uint[]{5,730,739});
          FontList.Add('o',new uint[]{5,740,749});
          FontList.Add('p',new uint[]{5,750,759});
          FontList.Add('q',new uint[]{5,760,769});
          FontList.Add('r',new uint[]{3,770,775});
          FontList.Add('s',new uint[]{4,776,783});
          FontList.Add('t',new uint[]{3,784,789});
          FontList.Add('u',new uint[]{5,790,799});
          FontList.Add('v',new uint[]{5,800,809});
          FontList.Add('w',new uint[]{7,810,823});
          FontList.Add('x',new uint[]{5,824,833});
          FontList.Add('y',new uint[]{5,834,843});
          FontList.Add('z',new uint[]{4,844,851});
          FontList.Add('{',new uint[]{4,852,859});
          FontList.Add('|',new uint[]{1,860,861});
          FontList.Add('}',new uint[]{4,862,869});
          FontList.Add('~',new uint[]{7,870,884});
        }
    }
}
